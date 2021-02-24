using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RPSSeleniumClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Data Data = new Data();
            Data.BaseUrl = "http://localhost/RPSNextShopping/";
            Data.CodCompany = "001";
            Data.User = "admin";
            Data.Password = "admin";
            Data.To = @"D:\BasoaCustomizationsGitHub\CuShoppingUnitTest\CuShoppint.Test";
            Data.Customer = "CuShopping";      
           
            ModelDownloader downloader = new ModelDownloader { BaseURL = Data.BaseUrl, CodCompany = Data.CodCompany, Password = Data.Password, User = Data.User };
            downloader.DownloadedFile += Downloader_DownloadedFile;
            downloader.Init();
            downloader.GetAllModels();
            var services = downloader.AvailableModels.Select(d => d.Service).Distinct();
            Console.WriteLine("This are the available services:");
            services.OrderBy(d=>d).ToList().ForEach(d => Console.WriteLine(d));
            Dictionary<string, TimeSpan> duration = new Dictionary<string, TimeSpan>();
            SeleniumConfigToStrign configfile = new SeleniumConfigToStrign();
            configfile.GenerateCS(Data.To,Data.BaseUrl,Data.User,Data.Password,Data.CodCompany);
            

            downloader.DownloadModels();

            
            downloader.End();
            foreach (var s in services)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Procesing service " + s);
                Console.WriteLine("------------------------------------------------");
              
               
                var from = Path.Combine(downloader.BaseFolderPath, s);
                var files = Directory.GetFiles(from, "*.uimodel", SearchOption.AllDirectories);
                
                //Parallel.ForEach<string>(files,new ParallelOptions { MaxDegreeOfParallelism = 1 },  new Action<string>((file) =>                   
                foreach(var file in files)
                {


                    Console.WriteLine($"Procesando fichero {file}");
                    using (var model = new RPSUIModelParser.UIModel(file, Data.Customer))
                    {
                        Console.WriteLine($"Generando codigo para modelo {model.FullPath}");
                        using (UIModelToString uims = new UIModelToString())
                        {
                            var text = uims.GenerateCS(model);

                            using (CSFile f = new CSFile())
                            {
                                f.FolderPath = Data.To;
                                f.Content = text;
                                f.FileName = model.Name + ".cs";
                                f.Package = model.Package;
                                f.Service = model.Service;
                                f.Version = model.Version;
                                f.Customer = model.Customer;
                                var t1 = f.Save();

                                var t2 = uims.GenerateUnitTestCS(model, Data.To);
                                Task.WaitAll(t1, t2);
                            }
                            Console.WriteLine($"");
                        }
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                //));
               
                Console.WriteLine("Generacion terminadad "+s);
                sw.Stop();
                duration.Add(s, sw.Elapsed);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
           
            //}
            GC.Collect();
            GC.WaitForPendingFinalizers();
           
            Console.WriteLine("Generacion terminadad Ok");
            duration.Keys.OrderBy(k=>k).ToList().ForEach(k =>
            {
                var value = duration[k];
                int minutes = (int)value.TotalSeconds / 60;
                int seconds = (int)value.TotalSeconds % 60;
                Console.WriteLine($"{k} in {value.ToString(@"hh\:mm\:ss")}");
            });
            ErrorManagement.ToScreen();
            ErrorManagement.ToFile(@"U:\classgenerator.txt");
            Console.ReadLine();

        }

        private static void Downloader_DownloadedFile(object sender, DownloadedUIMODEL e)
        {
            Console.WriteLine($"Downloaded {e.Service}-{e.Component} to {e.FilePath}");
        }

      
    }
    public class Data
    {
        public string From { get; set; }
        public string To { get; set; }
        public string BaseUrl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string CodCompany { get; set; }
        public string Customer { get; set; }
    }
}
