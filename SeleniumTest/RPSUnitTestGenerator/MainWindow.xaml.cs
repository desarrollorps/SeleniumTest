using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPSUnitTestGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RPS LoginForm = null;
        public MainWindow()
        {
            InitializeComponent();
            this.Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
           if (this.LoginForm != null)
            {
                this.LoginForm.Hide();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (LoginForm == null)
            {

                LoginForm = new RPS(this);
            }

            LoginForm.Show();
        }
    }
}
