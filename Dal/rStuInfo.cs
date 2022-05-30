using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class rStuInfo
    {

        public List<rgeInfo> GetList(rgeInfo mi)
        {
            //定义一个集合，用于转存数据
            List<rgeInfo> list = new List<rgeInfo>();
            //构造sql语句
            string sql = "select * from account";
            List<SqlParameter> listP = new List<SqlParameter>();
            //拼接查询条件,得到结果
            if (mi != null)
            {
                sql += " where usename=@name and passwd=@pwd";
                listP.Add(new SqlParameter("@name", mi.usename));  //把mi.MName赋值给@name
                listP.Add(new SqlParameter("@pwd",mi.usepasswd));
            }
            //执行查询，得到结果
            DataTable dt = SqliteHelper.GetList(sql, listP.ToArray());
            //逐渐遍历集合，将表中的数据存到集合中
            foreach (DataRow row in dt.Rows)
            {
                /**
                 * 1、先写list.add()方法
                 * 2、new ManagerInfo()
                 * 3、{对象的初始化器}
                 */
                list.Add(new rgeInfo()
                {
                    usename = row["usename"].ToString(),
                    usepasswd = row["passwd"].ToString(),
                    usetype =row["type"].ToString(),
                    Tel = row["Tel"].ToString(),
                });
            }
            //返回集合
            return list;
        }
        public int Insert(rgeInfo mi)
        {
            string sql = "insert into account(usename,passwd,type,Tel) values(@name,@pwd,@type,@Tel)";
            //数组的初始化器
            SqlParameter[] ps =
            {
                new SqlParameter("@name",mi.usename),
                new SqlParameter("@pwd",mi.usepasswd),
                new SqlParameter("@type",mi.usetype),
                new SqlParameter("@Tel",mi.Tel)
            };
            //执行
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
