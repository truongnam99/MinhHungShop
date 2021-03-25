using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DBContextIns: MinhHungShopContext
    {
        static DBContextIns ins = null;

        private DBContextIns()
        {

        }

        public static DBContextIns getIns()
        {
            if (ins == null)
            {
                ins = new DBContextIns();
            }
            return ins;
        }

    }
}
