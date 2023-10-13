using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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


public void ShowMessage(string message)
    {
        MessageBox.Show(message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
    }


    private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }



        //using System;
        //using System.Data.SqlClient;
        //using System.Windows;

        //namespace WpfApp
        //    {
        //        public partial class MainWindow : Window
        //        {
        //            public MainWindow()
        //            {
        //                InitializeComponent();
        //            }

        //            private void Button_Click(object sender, RoutedEventArgs e)
        //            {
        //                try
        //                {
        //                    // Conectarse a la base de datos
        //                    using (SqlConnection connection = new SqlConnection("TuCadenaDeConexion"))
        //                    {
        //                        connection.Open();

        //                        // Llamar al procedimiento almacenado
        //                        using (SqlCommand command = new SqlCommand("sp_MiProcedimiento", connection))
        //                        {
        //                            // Establecer el tipo de comando como procedimiento almacenado
        //                            command.CommandType = System.Data.CommandType.StoredProcedure;

        //                            // Agregar parámetros si es necesario
        //                            // command.Parameters.AddWithValue("@Parametro1", valor1);
        //                            // command.Parameters.AddWithValue("@Parametro2", valor2);

        //                            // Ejecutar el procedimiento almacenado
        //                            command.ExecuteNonQuery();
        //                        }

        //                        // Realizar otras operaciones si es necesario
        //                    }
        //                }
        //                catch (SqlException ex)
        //                {
        //                    // Manejar la excepción de SQL
        //                    MessageBox.Show("Error de SQL: " + ex.Message);
        //                }
        //                catch (Exception ex)
        //                {
        //                    // Manejar otras excepciones generales
        //                    MessageBox.Show("Error general: " + ex.Message);
        //                }
        //            }
        //        }
        //    }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try


            {
                using (SqlConnection connection = new SqlConnection("Data Source=MARIADELMAR\\UMCA; Initial Catalog=U_U; Integrated Security=false;Connect Timeout=30;Application Name=Gemas;User ID=sa;Password=umca2022*;"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_insertCouXStu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros necesarios
                        clsCXS data = new clsCXS(Convert.ToInt32(txtStuId.Text), txtCOU_ID.Text, float.Parse(txt_SCORE.Text), txt_PRD.Text, txt_STATUS.Text, clsGlobalValue.userLogin, DateTime.Now);

                        command.Parameters.AddWithValue("@p_STUID", data.Stu_id);
                        command.Parameters.AddWithValue("@p_COUID", data.Cou_id);
                        command.Parameters.AddWithValue("@p_CXSSCORE", data.Cxs_score);
                        command.Parameters.AddWithValue("@p_CXSPRD", data.Cxs_prd);
                        command.Parameters.AddWithValue("@pXS_STATUS", data.Cxs_status);
                        command.Parameters.AddWithValue("@pAddby", data.Cxs_addby);

                        SqlParameter errorMessageParameter = new SqlParameter("@pErrorMessage", SqlDbType.NVarChar, -1);
                        errorMessageParameter.Direction = ParameterDirection.Output; // Esto es esencial
                        command.Parameters.Add(errorMessageParameter);

                        command.ExecuteNonQuery();

                  

                        string errorMessage = command.Parameters["@pErrorMessage"].Value.ToString();

                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            MessageBox.Show("Error del procedimiento almacenado: " + errorMessage);
                        }
                        else
                        {
                            MessageBox.Show("Procedimiento almacenado ejecutado con éxito.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }




        




        //MANERA 2


        //try
        //{
        //    if (txtStuId.Text.Length > 0 && txtCOU_ID.Text.Length > 0 && txt_SCORE.Text.Length > 0 && txt_STATUS.Text != null)
        //    {
        //        clsCXS CXS = new clsCXS(Convert.ToInt32(txtStuId.Text), txtCOU_ID.Text, float.Parse(txt_SCORE.Text), txt_PRD.Text, txt_STATUS.Text, clsGlobalValue.userLogin, DateTime.Now);
        //        blCXS CXSB = new blCXS();
        //        if (CXSB.saveCxS(CXS) == true)
        //        {
        //            MessageBox.Show("[Éxito al guardar!");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Algo está mal!");
        //        }
        //        txtStuId.Text = "";
        //        txtCOU_ID.Text = "";
        //        txt_SCORE.Text = "";
        //        txt_STATUS.Text = "";
        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe llenar completar los espacios");
        //    }
        //}
        //catch (SqlException ex)
        //{

        //    TXTerrorTextBlock.Text = "Error general: " + ex.Message;
        //    throw new ApplicationException("Ha ocurrido un error general.", ex);
        //}





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