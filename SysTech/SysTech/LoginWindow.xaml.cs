using SysTech.CLASS;
using SysTech.TOOLS;
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
using System.Windows.Shapes;
using SysTech.LOGIC;

namespace SysTech
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            txtUsername.Text = clsGlobalValue.userLogin;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtPassword.Password.ToString().Length > 0)
            {
                clsUser user = new clsUser(txtUsername.Text, txtPassword.Password.ToString());

                //data transfer object DTO que comunica con la base de datos
                blUSER usu = new blUSER();
                if (usu.RequestLogin(user) == true)// function 
                {
                    clsGlobalValue.userLogin = txtUsername.Text;
                    MainWindow window = new MainWindow();
                    this.Close();
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Algo está mal!");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
