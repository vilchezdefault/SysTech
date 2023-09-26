using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using SysTech.CLASS;
using SysTech.LOGIC;
using SysTech.TOOLS;

namespace SysTech.WINDOWS
{
    /// <summary>
    /// Interaction logic for COUWindow.xaml
    /// </summary>
    public partial class COUWindow : Window
    {
        SqlConnection conn = new SqlConnection("Data Source=MARIADELMAR\\UMCA; Initial Catalog=U_U; Integrated Security=false;Connect Timeout=30;Application Name=Gemas;User ID=sa;Password=umca2022*;");

        public COUWindow()
        {
            InitializeComponent();
            txtUserLogg.Text = TOOLS.clsGlobalValue.userLogin;
            fillDATA();
        }

        private void btnMinimize_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtCOU_ID.Text) > 0 && txtCOU_NAME.Text.Length > 0 && txtMac_id.Text != null)
            {
                clsCOU COU = new clsCOU(Convert.ToInt32(txtCOU_ID.Text), txtCOU_NAME.Text, Convert.ToInt32(txtMac_id.Text), clsGlobalValue.userLogin, DateTime.Now);
                /// clsCOU COU = new clsCOU(txtCOU_NAME.Text, Convert.ToInt32(txtMac_id.Text), clsGlobalValue.userLogin, DateTime.Now);
                blCOU COUB = new blCOU();

                if (COUB.saveCOU(COU) == true)
                {
                    MessageBox.Show("Save complete!");

                }
                else
                {
                    MessageBox.Show("Wrong Data!");

                }
                txtCOU_ID.Text = "";
                txtCOU_NAME.Text = "";
                txtMac_id.Text = "";
            }
            else
            {
                MessageBox.Show("You need fo fill all spaces");
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCOU_ID.Text.Length > 0 && txtCOU_NAME.Text.Length > 0 && txtMac_id.Text != null)
            {
                clsCOU COUI = new clsCOU(0, Convert.ToInt32(txtCOU_ID.Text), txtCOU_NAME.Text, Convert.ToInt32(txtMac_id.Text), txtCOU_STATUS.Text, clsGlobalValue.userLogin, DateTime.Now);
                blCOU COUT = new blCOU();

                if (COUT.updateCOU(COUI) == true)
                {
                    MessageBox.Show("Update complete!");
                }
                else
                {
                    MessageBox.Show("Something its wrong");
                }
                txtCOU_ID.Text = "";
                txtCOU_NAME.Text = "";
                txtMac_id.Text = "";
                txtCOU_STATUS.Text = "";
            }
            else
            {
                MessageBox.Show("You need fo fill all spaces");
            }
        }

        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            fillDATA();
        }
        private void fillDATA()
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCourses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dtgCOU.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        //private void btnExel_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}




