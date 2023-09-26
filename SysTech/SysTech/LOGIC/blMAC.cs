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
    public class blMAC
    {
        private ConnSQL conn = new ConnSQL();//to create query
        private string _SQLConnection = Conn.GetConnectionStrings();

        SqlConnection cn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        /// <summary>
        /// Logic to save data into database (stored procedure)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool saveMAC(clsMAC data)
        {
            try
            {
                string query = "USE U_U; EXEC sp_insertCollage '" + data.Mac_id+"','"+data.Mac_name+"','"+data.Mac_addby+"';";
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
        /// Bussines Logic to update data from database (stored procedure)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool updateMAC(clsMAC data) 
        {
            try
            {
                //string query = "USE U_U; EXEC sp_updateCollage '" + data.Mac_id+"','"+data.Mac_name+"','"+data.Mac_updateby+"';";
                string query = "USE U_U; EXEC sp_updateCollage '" + data.Mac_id + "','" + data.Mac_name + "','" + data.Mac_status + "','" + data.Mac_updateby + "';";
                conn.SQLExecuteCmm(_SQLConnection, query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }


    }
}
