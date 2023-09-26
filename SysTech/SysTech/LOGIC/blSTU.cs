using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SysTech.CLASS;
using SysTech.DATABASE;

namespace SysTech.LOGIC
{
    public class blSTU
    {
        private ConnSQL conn = new ConnSQL();//to create query
        private string _SQLConnection = Conn.GetConnectionStrings();

        SqlConnection cn = new SqlConnection();
        SqlCommand com = new SqlCommand();


        /// <summary>
        /// Funtion to insert students by SQLI 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 

        //public bool saveSTU(clsSTU data)
        //{
        //    try
        //    {
        //        / string query = "INSERT INTO SI_U.dbo.TB_STUDENT VALUES('" + data.Stu_id + "','" + data.Mac_id + "','" + data.Stu_name + "','" + data.Stu_status + "','" + data.Stu_addby + "','" + data.Stu_dateadd.ToString("yyyy-MM-dd") + "',null,null);";
        //        / string query = "INSERT INTO SI_U.dbo.TB_STUDENT VALUES('" + data.Stu_id + "','" + data.Mac_id + "','" + data.Stu_name + "','" + data.Stu_status + "','" + data.Stu_addby + "'," + data.Stu_dateadd + ",null,null);";
        //        string query = "INSERT INTO SI_U.dbo.TB_STUDENT VALUES('" + data.Stu_id + "','" + data.Mac_id + "','" + data.Stu_name + "','" + data.Stu_status + "','" + data.Stu_addby + "','" + data.Stu_dateadd + "',null,null);";
        //        conn.SQLExecuteCmm(_SQLConnection, query);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error: " + ex.Message);
        //        return false;
        //    }

        //}


        /// <summary>
        /// Bussines logic to save student by stored procedure
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public bool HOLA(clsSTU data)
        {
            try
            {
                ///string query = "INSERT INTO SI_U.dbo.TB_STUDENT VALUES('" + data.Stu_id + "','" + data.Mac_id + "','" + data.Stu_name + "','" + data.Stu_status + "','" + data.Stu_addby + "','" + data.Stu_dateadd.ToString("yyyy-MM-dd") + "',null,null);";
                ///string query = "INSERT INTO SI_U.dbo.TB_STUDENT VALUES('"+ data.Stu_id+"','"+data.Mac_id+"','"+data.Stu_name+"','"+data.Stu_status+"','"+data.Stu_addby+"',"+data.Stu_dateadd+",null,null);";
                ///string query = "USE SI_U; EXEC sp_insertStudent '" + data.Stu_id + "','" + data.Mac_id + "','" + data.Stu_status + "','" + data.Stu_name + "','" + data.Stu_addby + "';";   
                ///

                //string query = "USE SI_U; EXEC sp_insertStudent '" + data.Stu_id + "','" + data.Mac_id + "','" + data.Stu_name + "','" + data.Stu_addby + "';";
                string query = "USE U_U; EXEC sp_insertStudent '"+data.Stu_id+"','"+data.Mac_id+"','"+data.Stu_name+"','"+data.Stu_LastName+"','"+data.Stu_addby+"';";
                conn.SQLExecuteCmm(_SQLConnection, query);
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }
        /// <summary>
        /// Bussines logic update student by store procedure
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool updateSTU(clsSTU data)
        {
            try
            {
                //string query = "USE SI_U; EXEC sp_updateStudent '"+data.Stu_id+"','"+data.Mac_id+"','" + data.Stu_name + "','" + data.Stu_updateby + "';";
                //string query = "USE SI_U; EXEC sp_updateStudent '"+data.Stu_id+"','"+data.Mac_id+"','"+data.Stu_name+"','"+data.Stu_updateby+"';";
                string query = "USE U_U; EXEC sp_updateStudent '"+data.Stu_id+"','"+data.Mac_id+"','"+data.Stu_name+"','"+data.Stu_LastName+"','"+data.Stu_updateby+"','"+data.Stu_status+"';";
                conn.SQLExecuteCmm( _SQLConnection, query);
                return true;
            }
            catch (Exception ex )
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }
}
