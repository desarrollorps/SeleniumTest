using RPSSeleniumClassGenerator;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para RPS.xaml
    /// </summary>
    public partial class RPS : Window
    {
        MainWindow previouswindow = null;
        RPSServices servicesscreen = null;
        public RPS(MainWindow w)
        {
            this.previouswindow = w;
            this.Activated += RPS_Activated;
            this.IsVisibleChanged += RPS_IsVisibleChanged;
            InitializeComponent();
        }

        private void RPS_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.servicesscreen != null && (bool)e.NewValue == true)
            {
                this.servicesscreen.Close();
                this.servicesscreen = null;
                this.btnContinue.IsEnabled = false;
                if (downloader != null)
                {
                    downloader.End();
                    downloader = null;
                }
            }
        }

        private void RPS_Activated(object sender, EventArgs e)
        {
            if(this.previouswindow != null)
            {
                this.previouswindow.Hide();
            }
        }

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tbUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnContinue.IsEnabled = false;
        }

        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btnContinue.IsEnabled = false;
        }
        ModelDownloader downloader = null;

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (downloader!= null)
            {
                downloader.End();
                downloader = null;
            }
            downloader = new ModelDownloader { BaseURL = tbRPS.Text, CodCompany =tbCodCompany.Text, Password =tbPassword.Password, User =tbUser.Text };
            downloader.DownloadedFile += (s,ev)=> { };
            if (downloader.Init())
            {
             //   downloader.GetAllModels();
                btnContinue.IsEnabled = true;
                MessageBox.Show("Connected to RPS", "RPS");
            }
            else
            {
                MessageBox.Show("Error connecting to RPS","RPS");
            }
        }

        private void btnSaveAsDefault_Click(object sender, RoutedEventArgs e)
        {
            addOrUpdateKey("url", tbRPS.Text);
            addOrUpdateKey("user", tbUser.Text);
            addOrUpdateKey("password", tbPassword.Password);
            addOrUpdateKey("codcompany", tbCodCompany.Text);
            addOrUpdateKey("language", tbLanguage.Text);
        }
        protected void addOrUpdateKey(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings.Remove(key);
                config.AppSettings.Settings.Add(key, value);
            }
            
            config.Save(ConfigurationSaveMode.Minimal);
        
        }
        protected string GetKey(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                return config.AppSettings.Settings[key].Value.ToString();
            }
            return "";
            

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            servicesscreen = new RPSServices(this);
            servicesscreen.modeldownloader = this.downloader;
            servicesscreen.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbRPS.Text = GetKey("url");
            tbUser.Text = GetKey("user");
            tbPassword.Password = GetKey("password");
            tbCodCompany.Text = GetKey("codcompany");
            tbLanguage.Text = GetKey("language");
            if (string.IsNullOrEmpty(tbRPS.Text))
            {
                tbRPS.Text = "http://localhost/rpsnextservice/";
            }
            if (this.servicesscreen != null)
            {
                this.servicesscreen.Close();
                this.servicesscreen = null;
                this.btnContinue.IsEnabled = false;
                if (downloader != null)
                {
                    downloader.End();
                    downloader = null;
                }
            }
        }
    }
}
