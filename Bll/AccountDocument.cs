using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace Bll
{
    public class AccountDocument
    {
        private AccountDAL account = new AccountDAL();
        public List<rgeInfo> GetList(string name)
        {
            return account.GetList(name);
        }
        public List<rgeInfo> GetList2()
        {
            return account.GetList2();
        }
        public bool Add(string name, string passwd,string type,string Tel)
        {
            rgeInfo dp = new rgeInfo();
            dp.usename = name; dp.usepasswd= passwd;dp.usetype = type;dp.Tel = Tel;
            return account.Insert(dp) > 0;
        }

        public bool Edit(string name, string passwd,string type, string Tel)
        {
            rgeInfo dp = new rgeInfo();
            dp.usename = name; dp.usepasswd = passwd; dp.usetype = type;dp.Tel = Tel;
            return account.Update(dp) > 0;
        }
        public bool Edit2(string name, string passwd, string type)
        {
            rgeInfo dp = new rgeInfo();
            dp.usename = name; dp.usepasswd = passwd; dp.usetype = type;
            return account.Update2(dp) > 0;
        }
        public bool Remove(string name)
        {
            return account.Delete(name) > 0;
        }
    }
}
