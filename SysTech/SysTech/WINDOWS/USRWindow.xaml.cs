using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
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
using SysTech.CLASS;
using SysTech.DATABASE;
using SysTech.LOGIC;
using SysTech.TOOLS;

namespace SysTech.WINDOWS
{
    /// <summary>
    /// Interaction logic for USRWindow.xaml
    /// </summary>
    public partial class USRWindow : Window
    {
        public USRWindow()
        {
            InitializeComponent();
            txtUserLogg.Text = TOOLS.clsGlobalValue.userLogin;
          
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string status;

            if (txtUsername.Text.Length > 0 && txtPassword != null)
            {
                if (ckStatus.IsChecked == true)
                {
                    status = "A";
                }
                else
                {
                    status = "I";
                }
                clsUser user = new clsUser(txtUsername.Text, txtPassword.Text, status, clsGlobalValue.userLogin, DateTime.Now);

                blUSER userT = new blUSER();
                if (userT.saveUser(user) == true)
                {
                    MessageBox.Show("Exito al guardar!");
                }
                else
                {
                    MessageBox.Show("Algo está mal!");

                }

                txtUsername.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Necesita completar todos los campos");
            }
        
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
