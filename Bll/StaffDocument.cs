using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace Bll
{
    public class StaffDocument
    {
        private absenceDal staff= new absenceDal();
        public List<workInfo> GetList(string id,string name)
        {
            return staff.GetList(id,name);
        }
        public List<workInfo> GetList2()
        {
            return staff.GetList2();
        }
        public bool Add(string id,string name,int age,string sex,string department_id,string post)
        {
            workInfo wk = new workInfo();
            wk.W_id = id; wk.Wname = name; wk.Wage=age; wk.Wsex = sex; wk.Wdepartment_id = department_id; wk.Wpost = post;
            return staff.Insert(wk) > 0;
        }

        public bool Edit(string id, string name,int age,string sex,string department_id, string post)
        {
            workInfo wk = new workInfo();
            wk.W_id = id; wk.Wname = name; ;wk.Wage = age; wk.Wsex=sex; wk.Wdepartment_id = department_id; wk.Wpost = post;
            return staff.Update(wk) > 0;
        }
        public bool Remove(string id)
        {
            return staff.Delete(id) > 0;
        }
    }
}
