using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTech.CLASS
{
    public class clsUser
    {
        #region Attributtes
        private int cero;
        private string UserName;
        private string password;
        private string addby;
        private string updateby;
        private string status;
        private DateTime addDate;
        private DateTime updateDate;
        #endregion Attibutes
        public clsUser()
        {
            this.UserName = "";
            this.password = "";
        }
        /// <summary>
        /// CONSTRUCTOR TO SAVE USER
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="status"></param>
        /// <param name="addby"></param>
        /// <param name="addDate"></param>
        public clsUser(string UserName, string Password, string status, string addby, DateTime addDate)
        {
            this.UserName = UserName;
            this.password = Password;
            this.status = status;
            this.addby = addby;
            this.addDate = addDate;

        }

        public clsUser(string UserName, string Password)
        {
            this.UserName = UserName;
            this.password = Password;

        }
        public clsUser(int id, string UserName, string Password)
        {
            this.UserName = UserName;
            this.password = Password;

        }

        public clsUser(string UserName, string Password, string addby)
        {

            this.UserName = UserName;
            this.password = Password;
            this.addby = addby;
            //this.addDate = addDate;

        }


        #region Functioons or procedures
        public string printData()
        {
            string data = "";
            data = "Username" + this.UserName + "\n" +
                   "Password" + this.password + "\n";
            return data;
        }
        #endregion  Function or procedures
        #region Gets & Set
        public string UserName_prop
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public string Password_prop
        {
            get { return password; }
            set { password = value; }
        }


        public string Addby
        {
            set { addby = value; }
            get { return addby; }
        }
        public string Updateby
        {
            set { updateby = value; }
            get { return updateby; }
        }
        public DateTime AddDate
        {
            set { addDate = value; }
            get { return addDate; }
        }
        public DateTime UpdateDate
        {
            set { updateDate = value; }
            get { return updateDate; }
        }
        public string Status
        {
            set { status = value; }
            get { return status; }
        }


        public int Cero
        {
            set { cero = value; }
            get { return cero; }
        }

        #endregion
    

    }
}
