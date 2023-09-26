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
using SysTech.CLASS;
using SysTech.LOGIC;
using SysTech.TOOLS;

namespace SysTech.WINDOWS
{
    /// <summary>
    /// Interaction logic for STUWindow.xaml
    /// </summary>
    public partial class STUWindow : Window
    {
        SqlConnection conn = new SqlConnection("Data Source=MARIADELMAR\\UMCA; Initial Catalog=U_U; Integrated Security=false;Connect Timeout=30;Application Name=Gemas;User ID=sa;Password=umca2022*;");

        public STUWindow()
        {
            InitializeComponent();
            txtUserLogg.Text = TOOLS.clsGlobalValue.userLogin;
            FillDaTa();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Bussines logic to save data into database(stored procedure)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (txtStuId.Text.Length > 0 && txtMacId.Text.Length > 0 && txtStuName.Text != null)
            {

                clsSTU STU = new clsSTU(Convert.ToInt32(txtStuId.Text), txtMacId.Text, txtStuName.Text, txtStuLastName.Text, clsGlobalValue.userLogin, DateTime.Now);

                blSTU STUT = new blSTU();
                if (STUT.HOLA(STU) == true)
                {
                    MessageBox.Show("Éxito al guardar!");
                }
                else
                {
                    MessageBox.Show("Algo está mal!");

                }

                txtStuId.Text = "";
                txtStuName.Text = "";
                txtMacId.Text = "";
                txtStuStatus.Text = "";
                txtStuLastName.Text = "";
            }
            else
            {
                MessageBox.Show("Debe llenar todos los espacios");
            }

        }
        /// <summary>
        /// Bussines Logic to update data from database (stored procedure) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtStuId.Text.Length > 0 && txtMacId.Text.Length > 0 && txtStuName.Text != null)
            {
                //clsSTU STUP = new clsSTU(Convert.ToInt32(txtStuId.Text), Convert.ToInt32(txtMacId.Text), txtStuName.Text, clsGlobalValue.userLogin, DateTime.Now);

                clsSTU STUP = new clsSTU(0,Convert.ToInt32(txtStuId.Text),txtMacId.Text,txtStuName.Text, txtStuLastName.Text,clsGlobalValue.userLogin,txtStuStatus.Text,DateTime.Now);
                blSTU sTU = new blSTU();

                if (sTU.updateSTU(STUP) == true)
                {
                    MessageBox.Show("Modificación exitosa!");
                }
                else
                {
                    MessageBox.Show("Algo está mal");
                }
                txtStuId.Text = "";
                txtStuName.Text = "";
                txtMacId.Text = "";
                txtStuStatus.Text = "";
                txtStuLastName.Text = "";
            }
            else
            {
                MessageBox.Show("Debe llenar todos los espacios");
            }
        }

        private void btnLookInfo_Click(object sender, RoutedEventArgs e)
        {
            FillDaTa();
        }

        private void FillDaTa()
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetStudenT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dtgSTU.ItemsSource = dt.DefaultView;

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

    }
}
