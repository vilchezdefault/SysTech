using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTech.CLASS
{
    public class clsRed
    {
        #region Attributes

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion
        #region Constructors

        public clsRed()
        {
            this.id = 0;
        }

        public clsRed(int id)
        {
            this.id = id;
        }

        #endregion


    }
}
