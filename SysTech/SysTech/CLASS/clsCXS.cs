using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTech.CLASS
{
    public class clsCXS
    {
        #region Attributes
        private int id;
        private string cou_id;
        private int stu_id;
        //private string stu_name;
        private string cxs_status;
        private float cxs_score;
        private string cxs_addby;
        private DateTime cxs_dateadd;
        private string cxs_updateby;
        private DateTime cxs_updatedate;
        #endregion

        #region Constructors
        public clsCXS()
        {
            this.cou_id = "";
            this.stu_id = 0;
            this.cxs_status = "";
            this.cxs_addby = "";
            this.cxs_dateadd = DateTime.Now;
            this.cxs_updateby = "";
            this.cxs_updatedate = DateTime.Now;

        }

        public clsCXS(int stu_id, string cou_id, float cxs_score, string cxs_status, string cxs_addby, DateTime cxs_dateadd)
        {
            this.stu_id = stu_id;
            this.cou_id = cou_id;
            this.cxs_score = cxs_score;
            this.cxs_status = cxs_status;
            this.cxs_addby = cxs_addby;
            this.cxs_dateadd = cxs_dateadd;
        }

        public clsCXS(int k, int id, int stu_id, string cou_id, float cxs_score, string cxs_status, string cxs_updateby, DateTime cxs_updatedate)
        {
            k = 0;
            this.id = id;
            this.stu_id = stu_id;
            this.cou_id = cou_id;
            this.cxs_score = cxs_score;
            this.cxs_status = cxs_status;
            this.cxs_updateby = cxs_updateby;
            this.cxs_updatedate = cxs_updatedate;
        }

        #endregion

        #region Metetods
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Cou_id
        {
            get { return cou_id; }
            set { cou_id = value; }
        }
        public int Stu_id
        {
            get { return stu_id; }
            set { stu_id = value; }
        }
        public string Cxs_status
        {
            get { return cxs_status; }
            set { cxs_status = value; }
        }
        public string Cxs_addby
        {
            get { return cxs_addby; }
            set { cxs_addby = value; }
        }

        public DateTime Cxs_dateadd
        {
            get { return cxs_dateadd; }
            set { cxs_dateadd = value; }
        }

        public string Cxs_updateby
        {
            get { return cxs_updateby; }
            set { cxs_updateby = value; }
        }
        public DateTime Cxs_updatedate
        {
            get { return cxs_updatedate; }
            set { cxs_updatedate = value; }
        }

        public float Cxs_score
        {
            get { return cxs_score; }
            set { cxs_score = value; }
        }
        #endregion

    }
}
