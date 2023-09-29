using SysTech.CLASS;
using SysTech.LOGIC;
using SysTech.TOOLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace SysTech.WINDOWS
{
    /// <summary>
    /// Interaction logic for REDSTU.xaml
    /// </summary>
    public partial class REDSTU : Window
    {

        SqlConnection conn = new SqlConnection("Data Source=MARIADELMAR\\UMCA; Initial Catalog=U_U; Integrated Security=false;Connect Timeout=30;Application Name=Gemas;User ID=sa;Password=umca2022*;");

        public REDSTU()
        {
            InitializeComponent();
            //TOOLS.clsGlobalValue.STU_ID = Convert.ToInt32(txtID.Text);
            txtUserLogg.Text = TOOLS.clsGlobalValue.userLogin;
            txtID.Text = TOOLS.clsGlobalValue.STU_ID;
       }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fillDATA()
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("recordXSTU", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dtgred.ItemsSource = dt.DefaultView;

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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
