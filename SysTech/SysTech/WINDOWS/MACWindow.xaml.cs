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
    /// Interaction logic for MACWindow.xaml
    /// </summary>
    public partial class MACWindow : Window
    {
        SqlConnection conn = new SqlConnection("Data Source=MARIADELMAR\\UMCA; Initial Catalog=U_U; Integrated Security=false;Connect Timeout=30;Application Name=Gemas;User ID=sa;Password=umca2022*;");


        public MACWindow()
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtMAC_ID.Text.Length > 0 && txtMAC_NAME.Text != null)
            {
                clsMAC MAC = new clsMAC(txtMAC_ID.Text, txtMAC_NAME.Text, clsGlobalValue.userLogin, DateTime.Now);
                blMAC MACC = new blMAC();
                if (MACC.saveMAC(MAC) == true)
                {
                    MessageBox.Show("Éxito al guardar!");
                }
                else
                {
                    MessageBox.Show("Algo está mal!");
                }

                txtMAC_ID.Text = "";
                txtMAC_NAME.Text = "";
                txtMAC_STATUS.Text ="";
            }
            else
            {
                MessageBox.Show("Debe Completar todos los espacios");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtMAC_ID.Text.Length > 0 && txtMAC_NAME.Text != null)
            {
                clsMAC MAC = new clsMAC(0, txtMAC_ID.Text, txtMAC_NAME.Text,txtMAC_STATUS.Text ,clsGlobalValue.userLogin, DateTime.Now);
                blMAC MACU = new blMAC();
                if (MACU.updateMAC(MAC) == true)
                {
                    MessageBox.Show("Modificación con éxito!");
                }
                else
                {
                    MessageBox.Show("Datos incorrectos!");
                }

                txtMAC_ID.Text = "";
                txtMAC_NAME.Text = "";
                txtMAC_STATUS.Text ="";

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }
        }



        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            FillDaTa();
        }
        private void FillDaTa()
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetCollage", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dtgMAC.ItemsSource = dt.DefaultView;

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