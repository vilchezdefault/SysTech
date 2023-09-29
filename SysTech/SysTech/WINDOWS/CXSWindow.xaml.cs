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
using SysTech.DATABASE;
using SysTech.LOGIC;
using SysTech.TOOLS;

namespace SysTech.WINDOWS
{
    /// <summary>
    /// Interaction logic for CXSWindow.xaml
    /// </summary>==
    public partial class CXSWindow : Window
    {

        SqlConnection conn = new SqlConnection("Data Source=MARIADELMAR\\UMCA; Initial Catalog=U_U; Integrated Security=false;Connect Timeout=30;Application Name=Gemas;User ID=sa;Password=umca2022*;");

        public CXSWindow()
        {
            InitializeComponent();
            txtUserLogg.Text = TOOLS.clsGlobalValue.userLogin;
            fillDATA();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtStuId.Text.Length > 0 && txtCOU_ID.Text.Length > 0 && txt_SCORE.Text.Length > 0 && txt_STATUS.Text != null)
            {
                clsCXS CXS = new clsCXS(Convert.ToInt32(txtStuId.Text),txtCOU_ID.Text,float.Parse(txt_SCORE.Text),txt_PRD.Text, txt_STATUS.Text, clsGlobalValue.userLogin, DateTime.Now);
                blCXS CXSB = new blCXS();
                if (CXSB.saveCxS(CXS) == true)
                {
                    MessageBox.Show("[Éxito al guardar!");
                }
                else
                {
                    MessageBox.Show("Algo está mal!");
                }
                txtStuId.Text = "";
                txtCOU_ID.Text = "";
                txt_SCORE.Text = "";
                txt_STATUS.Text = "";
            }
            else
            {
                MessageBox.Show("Debe llenar completar los espacios");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtStuId.Text.Length > 0 && txtCOU_ID.Text.Length > 0 && txt_SCORE.Text.Length > 0 && txt_STATUS.Text != null)

            {
                ///USE SI_U; EXEC sp_updateCoueseXstudent 4,1508141,1012,50.25,'R','YAO'
                ///
                /// clsCXS CXS = new clsCXS(0,Convert.ToInt32(txtID.Text,Convert.ToInt32(txtStuId.Text),Convert.ToInt32(txtCOU_ID.Text),float.Parse(txt_SCORE.Text),txt_STATUS.Text,clsGlobalValue.userLogin,DateTime.Now);
                /// 

                clsCXS CXS = new clsCXS(0, Convert.ToInt32(txtID.Text), Convert.ToInt32(txtStuId.Text),txtCOU_ID.Text, float.Parse(txt_SCORE.Text),txt_PRD.Text ,txt_SCORE.Text, clsGlobalValue.userLogin, DateTime.Now);
                blCXS CXSB = new blCXS();
                if (CXSB.updateCxs(CXS) == true)
                {
                    MessageBox.Show("Éxito al modificar!");
                }
                else
                {
                    MessageBox.Show("Algo está mal");
                }
                txtStuId.Text = "";
                txtCOU_ID.Text = "";
                txt_SCORE.Text = "";
                txt_STATUS.Text = "";
            }
            else
            {
                MessageBox.Show("Debe completar todos los espacios");
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
                SqlCommand cmd = new SqlCommand("GetCourseStudentInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dtgCXS.ItemsSource = dt.DefaultView;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new REDSTU();
            //this.Close();
            window.Show();
        }
    }
    
}