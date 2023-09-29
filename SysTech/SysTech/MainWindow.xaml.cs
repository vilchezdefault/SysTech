using SysTech.WINDOWS;
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

namespace SysTech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btnSTU_Click(object sender, RoutedEventArgs e)
        {
            var window = new STUWindow();
            //this.Close();
            window.Show();
        }

        private void btnCOU_Click(object sender, RoutedEventArgs e)
        {
            var window = new COUWindow();
            //this.Close();
            window.Show();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            var window = new USRWindow();
            //this.Close();
            window.Show();
        }

        private void btnCXS_Click(object sender, RoutedEventArgs e)
        {
            var window = new CXSWindow();
           // this.Close();
            window.Show();
        }

        private void btnMAC_Click(object sender, RoutedEventArgs e)
        {
            var window = new MACWindow();
            //this.Close();
            window.Show();
        }

    }
}
