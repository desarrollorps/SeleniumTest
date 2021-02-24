using RPSSeleniumClassGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RPSUnitTestGenerator
{
    /// <summary>
    /// Lógica de interacción para GenerationProcess.xaml
    /// </summary>
    public partial class GenerationProcess : Window
    {
        
        public RPSServices rpsservices { get; set; }
        public GenerationProcess(RPSServices services)
        {
            InitializeComponent();
            this.rpsservices = services;
            errorList = new List<Error>();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            GenerateCode();

            //ErrorManagement.ToScreen();
            //ErrorManagement.ToFile(@"U:\classgenerator.txt");
        }
        protected async void GenerateCode()
        {
            List<string> services = null;
            SeleniumConfigToStrign configfile = new SeleniumConfigToStrign();
            configfile.GenerateCS(rpsservices.tbFolder.Text, this.rpsservices.modeldownloader.BaseURL,this.rpsservices.modeldownloader.User,this.rpsservices.modeldownloader.Password,this.rpsservices.modeldownloader.CodCompany);
            bool AllServices = rpsservices.AvailableServices[0].Selected;
            //rpsservices.modeldownloader.DownloadedFile += (s, ev) => WriteMessage($"service {ev.Service} component {ev.Component} to {ev.FilePath}");
            if (AllServices)
            {
                services = rpsservices.AvailableServices.Skip(1).Select(d => d.Name).ToList();
                tbMessage.Text = $"Downloading all services";
               



                
                 rpsservices.modeldownloader.DownloadModels();               

            }
            else
            {
                services = rpsservices.AvailableServices.Skip(1).Where(d => d.Selected).Select(d => d.Name).ToList();
            }
            string Customer = "Framework";
            string To = rpsservices.tbFolder.Text;
            foreach (var s in services)
            {
                if (!AllServices)
                {
                    tbMessage.Text = $"Downloading service {s}";
                    rpsservices.modeldownloader.DownloadModels(s);
                }
                await GenerateService(s, Customer, To);
            }
            rpsservices.modeldownloader.End();
            //}


            Application.Current.Dispatcher.Invoke(() =>
            {
                btnExit.IsEnabled = true;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                WriteMessage("Generacion terminadad Ok");
                errorList = ErrorManagement.Errors.ToList();
                FilterErrorList(tbFilter.Text);
            });
        }
        protected void FilterErrorList(string text)
        {
            List<Error> filtered = null;
            if (string.IsNullOrEmpty(text))
            {
                filtered = errorList.ToList();
            }
            else
            {
                filtered = errorList.Where(d => 
                (d.EType != ErrorType.IgnoredControl && d.EType == ErrorType.IgnoredControlInGrid) &&
                (
                    (!string.IsNullOrEmpty(d.CollectionName) && d.CollectionName.Contains(text)) ||
                    (!string.IsNullOrEmpty(d.ColName) && d.ColName.Contains(text)) ||
                    (!string.IsNullOrEmpty(d.EditorType) && d.EditorType.Contains(text)) ||
                    (!string.IsNullOrEmpty(d.FileName) && d.FileName.Contains(text)) ||
                    (!string.IsNullOrEmpty(d.Message) && d.Message.Contains(text)) ||
                    (!string.IsNullOrEmpty(d.ViewName) && d.ViewName.Contains(text))
                )
                ).ToList();
            }
            listControls.ItemsSource = null;
            listControls.ItemsSource = filtered;
           
        }
        public List<Error> errorList { get; set; }
        protected Task GenerateService(string s, string Customer, string To)
        {
            return Task.Run(() =>
            {
                WriteMessage("Procesing service " + s);
                var from = System.IO.Path.Combine(rpsservices.modeldownloader.BaseFolderPath, s);
                var files = Directory.GetFiles(from, "*.uimodel", SearchOption.AllDirectories);

                //Parallel.ForEach<string>(files,new ParallelOptions { MaxDegreeOfParallelism = 1 },  new Action<string>((file) =>                   
                foreach (var file in files)
                {
                    WriteMessage($"Procesando fichero {file}");
                    using (var model = new RPSUIModelParser.UIModel(file, Customer))
                    {
                        WriteMessage($"Generando codigo para modelo {model.FullPath}");
                        using (UIModelToString uims = new UIModelToString())
                        {
                            var text = uims.GenerateCS(model);

                            using (CSFile f = new CSFile())
                            {
                                f.FolderPath = To;
                                f.Content = text;
                                f.FileName = model.Name + ".cs";
                                f.Package = model.Package;
                                f.Service = model.Service;
                                f.Version = model.Version;
                                f.Customer = model.Customer;
                                var t1 = f.Save();

                                var t2 = uims.GenerateUnitTestCS(model, To);
                                Task.WaitAll(t1, t2);
                            }
                            WriteMessage($"");
                        }
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                //));

                WriteMessage("Generacion terminadad " + s);

                GC.Collect();
                GC.WaitForPendingFinalizers();
               
            });
        }
        protected void WriteMessage(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                tbMessage.Text = message + $":{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}";
            });
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterErrorList(tbFilter.Text);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        bool IsFirstTime = true;
        private void Window_Activated(object sender, EventArgs e)
        {/*
            if (IsFirstTime)
            {
                IsFirstTime = false;
                GenerateCode();
               
            }*/
        }
    }
}
