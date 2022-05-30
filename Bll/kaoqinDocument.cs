using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace Bll
{
    public class kaoqinDocument
    { 
        private kaoqinDAL staff = new kaoqinDAL();
        public List<kaoqinInfo> GetList(string Id,string user_id, string name)
        {
            return staff.GetList(Id,user_id, name);
        }
        public List<kaoqinInfo> GetList2()
        {
            return staff.GetList2();
        }
        public bool Add(string user_id, string name, string type, DateTime date)
        {
            kaoqinInfo wk = new kaoqinInfo();
            wk.user_id = user_id; wk.user_name= name; wk.type = type; wk.date = date;
            return staff.Insert(wk) > 0;
        }

        public bool Edit(string id,string user_id, string name, string type, DateTime date)
        {
            kaoqinInfo wk = new kaoqinInfo();
            wk.Id = id; wk.user_id = user_id; wk.user_name = name; wk.type = type; wk.date = date;
            return staff.Update(wk) > 0;
        }
        public bool Remove(string id)
        {
            return staff.Delete(id) > 0;
        }

        public List<kaoqinInfo> GetList3(string name, string type)
        {
            return staff.GetList3(name,type);
        }
    }
}
