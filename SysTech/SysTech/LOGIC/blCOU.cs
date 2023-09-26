using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SysTech.CLASS;
using SysTech.DATABASE;

namespace systemTec.LOGIC
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

        //public bool saveCOU(clsCOU data)
        //{
        //    try
        //    {
        //        string query = "USE SI_U; EXEC sp_insertCourse '" + data.Cou_id + "','" + data.Cou_name + "','" + data.Cou_addby + "','" + data.Mac_id + "';";
        //        conn.SQLExecuteCmm(_SQLConnection, query);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //        return false;
        //    }

        //}
        //public bool updateCOU (clsCOU data)
        //{
        //    try
        //    {
        //        string query = "USE SI_U; EXEC sp_updateCourse '"+data.Cou_id+"','"+data.Cou_name+"','"+data.Cou_status+"','"+data.Cou_updateby+"',"+data.Mac_id+";";
        //        conn.SQLExecuteCmm(_SQLConnection, query);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //        return false;
        //    }
        //}
    }
}
