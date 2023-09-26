using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SysTech.CLASS;
using SysTech.DATABASE;

namespace SysTech.LOGIC
{
    public class blCXS
    {
        private ConnSQL conn = new ConnSQL();//to create query
        private string _SQLConnection = Conn.GetConnectionStrings();

        SqlConnection cn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public bool saveCxS(clsCXS data)
        {
            try
            {
                string query = "USE U_U; EXEC sp_insertCouXStu '"+data.Stu_id+"','"+data.Cou_id+"','"+data.Cxs_score+"','"+data.Cxs_status+"','"+data.Cxs_addby+"';";
                conn.SQLExecuteCmm(_SQLConnection, query);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool updateCxs(clsCXS data)
        {

            try
            {
                string query = "USE U_U; EXEC sp_updateCoueseXstudent '"+data.Id+"','"+data.Stu_id+"','"+data.Cou_id+"','"+data.Cxs_score+"','"+data.Cxs_status+"','"+data.Cxs_updateby+"';";
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
