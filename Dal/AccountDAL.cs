using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Dal
{
    public class AccountDAL
    {
        public List<rgeInfo> GetList(string name)
        {
            string sql = "select * from account where usename=@Name";
            SqlParameter p = new SqlParameter("@Name", name);
            DataTable dt = SqliteHelper.GetList(sql, p);
            List<rgeInfo> list = new List<rgeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new rgeInfo()
                {
                    usename = row["usename"].ToString(),
                    usepasswd = row["passwd"].ToString(),
                    usetype = row["type"].ToString(),
                    Tel = row["Tel"].ToString()
                });

            }
            return list;

        }


        public List<rgeInfo> GetList2()
        {
            string sql = "select * from account where 1=1";
            DataTable dt = SqliteHelper.GetList(sql);
            List<rgeInfo> list = new List<rgeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new rgeInfo()
                {
                    usename = row["usename"].ToString(),
                    usepasswd = row["passwd"].ToString(),
                    usetype = row["type"].ToString(),
                    Tel = row["Tel"].ToString()

                });

            }
            return list;

        }

        public int Insert(rgeInfo dp)
        {
            string sql = "insert into account(usename,passwd,type,Tel) values(@Name,@Passwd,@Type,@Tel)";
            List<SqlParameter> listP = new List<SqlParameter>();
            if (dp != null)
            {
                listP.Add(new SqlParameter("@Name", dp.usename));
                listP.Add(new SqlParameter("@Passwd", dp.usepasswd));
                listP.Add(new SqlParameter("@Type", dp.usetype));
                listP.Add(new SqlParameter("@Tel", dp.Tel));
            }
            return SqliteHelper.ExecuteNonQuery(sql, listP.ToArray());

        }

        public int Update(rgeInfo dp)
        {
            string sql = "update account set passwd=@Passwd,type=@Type,Tel=@Tel where usename=@Name";

            SqlParameter[] ps =
            {
                new SqlParameter("@Name", dp.usename),
                new SqlParameter("@Passwd", dp.usepasswd),
                new SqlParameter("@Type", dp.usetype),
                new SqlParameter("@Tel", dp.Tel)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update2(rgeInfo dp)
        {
            string sql = "update account set passwd=@Passwd where usename=@Name";

            SqlParameter[] ps =
            {
                new SqlParameter("@Name", dp.usename),
                new SqlParameter("@Passwd", dp.usepasswd),
                new SqlParameter("@Type", dp.usetype),
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(string name)
        {
            string sql = "delete from account where usename = @Name";
            SqlParameter p = new SqlParameter("@Name", name);
            return SqliteHelper.ExecuteNonQuery(sql, p);

        }
    }
}
