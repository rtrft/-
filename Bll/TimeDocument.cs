using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class TimeDocument
    {
        private TimeDal td = new TimeDal();
        public bool Edit(DateTime time1,DateTime time2,DateTime time3,DateTime time4)
        {
            TimeInfo ti = new TimeInfo();
            ti.Time1 = time1; ti.Time2 =time2; ; ti.Time3 = time3;ti.Time4 = time4;
            return td.Update(ti) > 0;
        }
    }
}
