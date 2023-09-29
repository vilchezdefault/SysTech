using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTech.CLASS
{
    public class clsMAC
    {

        #region Attributes
        private string mac_id;
        private string mac_name;
        private string mac_status;
        private string mac_addby;
        private DateTime mac_dateadd;
        private string mac_updateby;
        private DateTime mac_updatedate;
       





        #endregion
        #region Constructors
        public clsMAC()
        {
            this.mac_id = "";
            this.mac_name = "";
            this.mac_status = "";
            this.mac_addby = "";
            this.mac_dateadd = DateTime.Now;
            this.mac_updateby = "";
            this.mac_updatedate = DateTime.Now;
            this.cou_requis = "";
        }
        /// <summary>
        /// Constructor to save collague
        /// </summary>
        /// <param name="mac_id"></param>
        /// <param name="mac_name"></param>
        /// <param name="mac_addby"></param>
        /// <param name="mac_dateadd"></param>

        public clsMAC(string mac_id, string mac_name, string mac_addby, DateTime mac_dateadd)
        {
            this.mac_id = mac_id;
            this.mac_name = mac_name;
            this.mac_addby = mac_addby;
            this.mac_dateadd = mac_dateadd;
        }

        public clsMAC(int k, string mac_id, string mac_name,string mac_status, string mac_updateby, DateTime mac_updatedate)
        {
            k = 0;
            this.mac_id = mac_id;
            this.mac_name = mac_name;
            this.mac_status = mac_status;
            this.mac_updateby = mac_updateby;
            this.mac_updatedate = DateTime.Now;
        }
        #endregion
        #region Metods

        #region Metods
        public string Mac_id
        {
            get { return mac_id; }
            set { mac_id = value; }
        }
        public string Mac_name
        {
            get { return mac_name; }
            set { mac_name = value; }
        }
        public string Mac_status
        {
            get { return mac_status; }
            set { mac_status = value; }
        }

        public string Mac_addby
        {
            get { return mac_addby; }
            set { mac_addby = value; }
        }

        public DateTime Mac_dateadd
        {
            get { return mac_dateadd; }
            set { mac_dateadd = value; }
        }

        public string Mac_updateby
        {
            get { return mac_updateby; }
            set { mac_updateby = value; }
        }
        public DateTime Mac_updatedate
        {
            get { return mac_updatedate; }
            set { mac_updatedate = value; }
        }
        private string cou_requis;
        public string Cou_requis
        {
            get { return cou_requis; }
            set { cou_requis = value; }
        }
        #endregion
        #endregion

    }
}
