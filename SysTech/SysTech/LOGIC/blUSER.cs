using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SysTech.DATABASE;
using SysTech.TOOLS;
using SysTech.CLASS;

namespace SysTech.LOGIC
{
    public class blUSER
    {
        private ConnSQL conn = new ConnSQL();//to create query
        private string _SQLConnection = Conn.GetConnectionStrings();

        SqlConnection cn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public bool RequestLogin(clsUser data)
        {
            try //dbo.TB _USERS
            {
                string query = "SELECT USR_USERNAME FROM U_U.dbo.TB_USER WHERE USR_USERNAME ='"
                    + data.UserName_prop + "' AND USR_PASSWORD = '" + data.Password_prop + "'";

                var exist = conn.SQLCargaDataTable(_SQLConnection, query, null);
                if (exist.Rows.Count > 0)
                {
                    clsGlobalValue.userLogin = data.UserName_prop;
                    return true;
                }
                else
                { 
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }
        public bool saveUser(clsUser data)
        {
            try
            {
                string query = "USE U_U; EXEC sp_insertUser '"+data.UserName_prop+"','"+data.Password_prop+"','"+data.Addby+"'";
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
