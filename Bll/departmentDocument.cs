using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace Bll
{
    public class departmentDocument
    {
        private departmentDAL department = new departmentDAL();
        public List<departmentInfo> GetList(string id,string name)
        {
            return department.GetList(id,name);
        }
        public List<departmentInfo> GetList2()
        {
            return department.GetList2();
        }
        public bool Add(string id, string name, string Load, string place)
        {
            departmentInfo dp = new departmentInfo();
            dp.D_id = id; dp.D_name = name; dp.D_Load = Load;dp.D_place = place;
            return department.Insert(dp) > 0;
        }

        public bool Edit(string id, string name, string Load, string place)
        {
            departmentInfo dp = new departmentInfo();
            dp.D_id = id; dp.D_name = name; dp.D_Load = Load; dp.D_place = place;
            return department.Update(dp) > 0;
        }
        public bool Remove(string id)
        {
            return department.Delete(id) > 0;
        }
    }
}
