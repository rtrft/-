using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace Bll
{
    public class rDocument
    {
        public bool rOne(string name, string passwd,string type,string Tel)
        {
            rStuInfo rStu = new rStuInfo();
            rgeInfo rge = new rgeInfo();
            rge.usename = name; rge.usepasswd = passwd;rge.usetype = type;rge.Tel = Tel;
            rStu.Insert(rge); 
            return true;
        }

        public List<rgeInfo> useQuiry(string name, string passwd)
        {
            rStuInfo rStu = new rStuInfo();
            rgeInfo rge = new rgeInfo();
            rge.usename = name; rge.usepasswd = passwd;
            return rStu.GetList(rge);
        }
    }
}
