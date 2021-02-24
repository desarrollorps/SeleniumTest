using RPSSeleniumClassGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RPSUnitTestGenerator
{
    /// <summary>
    /// Lógica de interacción para RPSServices.xaml
    /// </summary>
    public partial class RPSServices : Window
    {
        public RPS RPSView = null;
        public ModelDownloader modeldownloader { get; set; }
        public RPSServices(RPS view)
        {
            InitializeComponent();
            this.RPSView = view;
            this.Activated += RPSServices_Activated;
        }
        public List<Service> AvailableServices = new List<Service>();
        private void RPSServices_Activated(object sender, EventArgs e)
        {

            this.RPSView.Hide();
            if (this.modeldownloader != null)
            {
                this.modeldownloader.GetAllModels();
                var services = modeldownloader.AvailableModels.Select(d => d.Service).Distinct().ToList();
                services.Insert(0, "All");
                AvailableServices = services.Select(d => new Service { Name = d, Selected = false }).ToList();
                AvailableServices[0].Selected = true;
                this.listServices.ItemsSource = AvailableServices;
                this.btnContinue.IsEnabled = this.AvailableServices.Any(d => d.Selected);
            }
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolder.Text))
            {
                System.Windows.MessageBox.Show("The customer and destination folder must be filled to generate the code","RPS");
            }
            else
            {
                GenerationProcess process = new GenerationProcess(this);
                this.Hide();
                process.Show();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.RPSView.Show();
            
            this.Close();
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (this.AvailableServices[0].Selected)
            {
                this.AvailableServices.Skip(1).ToList().ForEach(d => d.Selected = false);
                this.listServices.ItemsSource = null;
                this.listServices.ItemsSource = AvailableServices;
            }
            this.btnContinue.IsEnabled = this.AvailableServices.Any(d => d.Selected);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
          
            this.btnContinue.IsEnabled = this.AvailableServices.Any(d => d.Selected);
        }

        private void browserDialog_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.tbFolder.Text = dialog.SelectedPath;
            }
        }
    }
    public class Service
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
