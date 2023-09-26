using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTech.CLASS
{
    public class clsCOU
    {

        #region Attributes
        private string cou_id;
        private string cou_name;
        private string cou_status;
        private string cou_addby;
        private DateTime cou_dateadd;
        private string cou_updateby;
        private DateTime cou_updatedate;
        #endregion

        #region Constructors
        public clsCOU()
        {
            this.cou_id = "";
            this.cou_name = "";
            this.cou_status = "";
            this.cou_addby = "";
            this.cou_dateadd = DateTime.Now;
            this.cou_updateby = "";
            this.cou_updatedate = DateTime.Now;
        }

        public clsCOU(string cou_id, string cou_name, int mac_id, string addby, DateTime adddate)
        {
            this.cou_id = cou_id;
            this.cou_name = cou_name;
            this.cou_addby = addby;
            this.cou_dateadd = adddate;

        }
        //public clsCOU( string cou_name, int mac_id,string addby,DateTime adddate)
        //{

        //    this.cou_name= cou_name;
        //    this.Mac_id = mac_id;
        //    this.cou_addby = addby;
        //    this.Cou_dateadd= adddate;

        //}    
        public clsCOU(int k, string cou_id, string cou_name, int mac_id, string cou_status, string updateby, DateTime updatedate)
        {
            k = 0;
            this.cou_id = cou_id;
            this.cou_name = cou_name;
            this.cou_status = cou_status;
            this.cou_updateby = updateby;
            this.cou_updatedate = updatedate;

        }

        #endregion

        #region Metods
        public string CouId
        {
            get { return cou_id; }
            set { cou_id = value; }
        }

        // Getter and Setter for cou_name
        public string CouName
        {
            get { return cou_name; }
            set { cou_name = value; }
        }

        // Getter and Setter for cou_status
        public string CouStatus
        {
            get { return cou_status; }
            set { cou_status = value; }
        }

        // Getter and Setter for cou_addby
        public string CouAddBy
        {
            get { return cou_addby; }
            set { cou_addby = value; }
        }

        // Getter and Setter for cou_dateadd
        public DateTime CouDateAdd
        {
            get { return cou_dateadd; }
            set { cou_dateadd = value; }
        }

        // Getter and Setter for cou_updateby
        public string CouUpdateBy
        {
            get { return cou_updateby; }
            set { cou_updateby = value; }
        }

        // Getter and Setter for cou_updatedate
        public DateTime CouUpdateDate
        {
            get { return cou_updatedate; }
            set { cou_updatedate = value; }
        }
        #endregion

    }

}

