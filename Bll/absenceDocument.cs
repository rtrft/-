using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class absenceDocument
    {
        private absenceDAL absence = new absenceDAL();
        public List<absenceInfo> GetList(string id,string name)
        {
            return absence.GetList(id,name);
        }

        public List<absenceInfo> GetList2()
        {
            return absence.GetList2();
        }
        public List<absenceInfo> GetList3(string name,string type)
        {
            return absence.GetList3(name,type);
        }

        public bool Edit(string id,string decision)
        {
            absenceInfo ab = new absenceInfo();
            ab.A_id = id;ab.A_decision= decision;
            return absence.Update(ab) > 0;
        }

        public bool Add(string id, string name, string type,DateTime ST,DateTime ET)
        {
            absenceInfo dp = new absenceInfo();
            dp.A_id = id; dp.A_name = name; dp.A_type = type; dp.Start_time = ST; dp.End_time = ET;
            return absence.Insert(dp) > 0;
        }

        public bool Edit2(string name, string type,DateTime ST,DateTime ET)
        {
            absenceInfo ab = new absenceInfo();
            ab.A_name = name; ab.A_type = type;ab.Start_time = ST;ab.End_time = ET;
            return absence.Update2(ab) > 0;
        }
        public bool Remove(string name)
        {
            absenceInfo ab = new absenceInfo();
            return absence.Delete(name) > 0;
        }
    }
}
