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
    public class blCOU
    {
        private ConnSQL conn = new ConnSQL();//to create query
        private string _SQLConnection = Conn.GetConnectionStrings();

        SqlConnection cn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        /// <summary>
        /// Bussines Logic
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public bool saveCOU(clsCOU data)
        {
            try
            {
                string query = "EXEC sp_insertCourse '" + data.CouId + "','" + data.CouName + "','" + data.CouAddBy + "','"+data.Cou_requis+"';";
                conn.SQLExecuteCmm(_SQLConnection, query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }
        public bool updateCOU(clsCOU data)
        {
            try
            {
                string query = "USE U_U; EXEC sp_updateCourse '"+data.CouId+"','"+data.CouName+"','"+data.CouStatus+"','"+data.CouUpdateBy+"';";
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
