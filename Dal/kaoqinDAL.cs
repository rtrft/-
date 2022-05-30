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
    public class kaoqinDAL
    {
        public List<kaoqinInfo> GetList(string Id,string user_id,string name)
        {
            string sql = "select * from kaoqin where user_id=@user_Id or user_name=@Name or id=@Id";
            SqlParameter[] ps =
            {
                new SqlParameter("@Id",Id),
                new SqlParameter("@user_Id",user_id),
                new SqlParameter("@Name",name),
             };
            DataTable dt = SqliteHelper.GetList(sql, ps);
            List<kaoqinInfo> list = new List<kaoqinInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new kaoqinInfo()
                {
                    Id = row["id"].ToString(),
                    user_id = row["user_id"].ToString(),
                    user_name = row["user_name"].ToString(),
                    type = row["type"].ToString(),
                    date= (DateTime)row["time"]
            });

            }
            return list;

        }


        public List<kaoqinInfo> GetList2()
        {
            string sql = "select * from kaoqin where 1=1;";
            DataTable dt = SqliteHelper.GetList(sql);
            List<kaoqinInfo> list = new List<kaoqinInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new kaoqinInfo()
                {
                    Id = row["id"].ToString(),
                    user_id = row["user_id"].ToString(),
                    user_name = row["user_name"].ToString(),
                    type = row["type"].ToString(),
                    date = (DateTime)row["time"]

                });

            }
            return list;

        }

        public List<kaoqinInfo> GetList3(string name,string type)
        {
            string sql = "select * from kaoqin where user_id=@Id and type=@Type";
            SqlParameter[] ps =
           {
                new SqlParameter("@Id",name),
                new SqlParameter("@Type",type),
             };
            DataTable dt = SqliteHelper.GetList(sql, ps);
            List<kaoqinInfo> list = new List<kaoqinInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new kaoqinInfo()
                {
                    Id = row["id"].ToString(),
                    user_id = row["user_id"].ToString(),
                    user_name = row["user_name"].ToString(),
                    type = row["type"].ToString(),
                    date = (DateTime)row["time"]
                });

            }
            return list;

        }



        public int Insert(kaoqinInfo wk)
        {
            string sql = "insert into kaoqin(user_id,user_name,type,time) values(@userId,@Name,@Type,@Time)";
            List<SqlParameter> listP = new List<SqlParameter>();
            if (wk != null)
            {
                listP.Add(new SqlParameter("@userId", wk.user_id));
                listP.Add(new SqlParameter("@Name", wk.user_name));
                listP.Add(new SqlParameter("@Type", wk.type));
                listP.Add(new SqlParameter("@Time", wk.date));
            }
            return SqliteHelper.ExecuteNonQuery(sql, listP.ToArray());

        }

        public int Update(kaoqinInfo wk)
        {
            string sql = "update kaoqin set user_name=@Name,type=@Type,time=@Time where id=@Id";

            SqlParameter[] ps =
            {
                new SqlParameter("@Id", wk.Id),
                new SqlParameter("@Name", wk.user_name),
                new SqlParameter("@Type", wk.type),
                new SqlParameter("@Time", wk.date)
             };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(string id)
        {
            string sql = "delete from kaoqin where  id = @Id";
            SqlParameter p = new SqlParameter("@Id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);

        }
    }
}
