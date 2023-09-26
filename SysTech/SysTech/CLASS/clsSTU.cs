using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTech.CLASS
{
    public  class clsSTU
    {
        #region Attributes
        private int stu_id;
        private string mac_id;
        private string stu_name;
        private string stu_lastname;
        private string stu_status;
        private string stu_addby;
        private DateTime stu_dateadd;
        private string stu_updateby;
        private DateTime stu_updatedate;
        #endregion

        #region Constructors
        public clsSTU()
        {
            this.stu_id = 0;
            this.mac_id = "";
            this.stu_name = "";
            this.stu_lastname = "";
            this.stu_status = "";
            this.stu_addby = "";
            this.stu_dateadd = DateTime.Now;
            this.stu_updateby = "";
            this.stu_updatedate = DateTime.Now;
        }

        /// <summary>
        /// Constructor to save datas into database
        /// </summary>
        /// <param name="id_stu"></param>
        /// <param name="id_mac"></param>
        /// <param name="stu_name"></param>
        /// <param name="addby"></param>
        /// <param name="adddate"></param>
        public clsSTU(int id_stu, string id_mac, string stu_name,string stu_lastname ,string addby, DateTime adddate)
        {
            this.stu_id = id_stu;
            this.mac_id = id_mac;
            this.stu_name = stu_name;
            this.stu_lastname = stu_lastname;
            this.stu_addby = addby;
            this.stu_dateadd = adddate;
        }


        /// <summary>
        /// Constructor to update info from data base 
        /// </summary>
        /// <param name="contardor"></param>
        /// <param name="stu_id"></param>
        /// <param name="mac_id"></param>
        /// <param name="stu_name"></param>
        /// <param name="stu_updateby"></param>
        /// <param name="stu_updatedate"></param>
        public clsSTU(int k, int stu_id, string mac_id, string stu_name,string stu_lastname, string stu_updateby,string stu_status, DateTime stu_updatedate)
        {
            k = 0;
            this.stu_id = stu_id;
            this.mac_id = mac_id;
            this.stu_name = stu_name;
            this.stu_lastname = stu_lastname;
            this.stu_updateby = stu_updateby;
            this.stu_status = stu_status;
            this.stu_updatedate = stu_updatedate;
        }
        #endregion

        #region Metods


        public int Stu_id
        {
            get { return stu_id; }
            set { stu_id = value; }
        }

        public string Mac_id
        {
            get { return mac_id; }
            set { mac_id = value; }
        }

        public string Stu_name
        {
            get { return stu_name; }
            set { stu_name = value; }
        }

        public string Stu_status
        {
            get { return stu_status; }
            set { stu_status = value; }
        }

        public string Stu_addby
        {
            get { return stu_addby; }
            set { stu_addby = value; }
        }

        public DateTime Stu_dateadd
        {
            get { return stu_dateadd; }
            set { stu_dateadd = value; }
        }

        public string Stu_updateby
        {
            get { return stu_updateby; }
            set { stu_updateby = value; }
        }
        public DateTime Stu_updatedate
        {
            get { return stu_updatedate; }
            set { stu_updatedate = value; }
        }
        public string Stu_LastName
        {
            get { return stu_lastname; }
            set { stu_lastname = value; }
        }
        #endregion


    }

}
