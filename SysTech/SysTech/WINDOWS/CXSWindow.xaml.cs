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
           // txtStuId.Text = TOOLS.clsGlobalValue.STU_ID;
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

                /*
                 *             this.id = id;
             this.stu_id = stu_id;
             this.cou_id = cou_id;
             this.cxs_score = cxs_score;
             this.Cxs_prd = cxs_prd;
             this.cxs_status = cxs_status;
             this.cxs_updateby = cxs_updateby;
             this.cxs_updatedate = cxs_updatedate;
                 * */

                //clsCXS CXS = new clsCXS(0, Convert.ToInt32(txtID.Text), Convert.ToInt32(txtStuId.Text),txtCOU_ID.Text, float.Parse(txt_SCORE.Text),txt_PRD.Text , clsGlobalValue.userLogin, DateTime.Now);   
                clsCXS CXS = new clsCXS(0, Convert.ToInt32(txtID.Text), Convert.ToInt32(txtStuId.Text),txtCOU_ID.Text, float.Parse(txt_SCORE.Text),txt_PRD.Text ,txt_STATUS.Text ,clsGlobalValue.userLogin, DateTime.Now);
                blCXS CXSB = new blCXS();
                if (CXSB.updateCxs(CXS) == true)
                {
                    MessageBox.Show("Transacción realizada");
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
        /// <summary>
        /// Funtion to request info from data base by store procedure and parameter(CLASES.CS NO DESDE BL)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void consultarRec(object sender,RoutedEventArgs e)
        //{
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("recordXSTU",conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //        //Parametros del procedimiento almacenado
        //        SqlParameter parameter = new SqlParameter("@pIDSTU",SqlDbType.Int);
        //       // parameter.Value = 0;
        //       cmd.Parameters.Add(parameter);
        //       DataTable dt = new DataTable();
        //        adapter.Fill(dt);   


        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //private void Llenar_DataGridView()
        //{
        //    //Los argumentos de conexion a la base de datos
        //    string args = "Data source=LAPTOP; Initial catalog=pubs; Integrated Security=SSPI";
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = args;

        //    try
        //    {
        //        //Indico el SP que voy a utilizar
        //        SqlCommand command = new SqlCommand("byroyalty", conn);
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter adapter = new SqlDataAdapter(command);

        //        //Envió los parámetros que necesito
        //        SqlParameter param = new SqlParameter("@percentage", SqlDbType.Int);
        //        param.Value = 100;
        //        command.Parameters.Add(param);

        //        DataTable dt = new DataTable();

        //        conn.Open();

        //        //Aquí ejecuto el SP y lo lleno en el DataTable
        //        adapter.Fill(dt);

        //        //Enlazo mis datos obtenidos en el DataTable con el grid
        //        //dataGridView1.DataSource = dt;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}



        private void btnRED_Click(object sender, RoutedEventArgs e)
        {
            var window = new REDSTU();
            //this.Close();
            window.Show();
        }
    }
    
}