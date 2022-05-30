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
    public class absenceDal
    {
        public List<workInfo> GetList(string id,string name)
        {
            string sql = "select * from staff where w_id=@Id or name=@Name";
            SqlParameter[] ps =
           {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", name),
             };
            DataTable dt = SqliteHelper.GetList(sql, ps);
            List<workInfo> list = new List<workInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new workInfo()
                {
                    W_id =  row["w_id"].ToString(),
                    Wname = row["name"].ToString(),
                    Wage = (int)row["age"],
                    Wsex = row["sex"].ToString(),
                    Wdepartment_id = row["department_id"].ToString(),
                    Wpost= row["post"].ToString()

                });

            }
            return list;

        }


        public List<workInfo> GetList2()
        {
            string sql = "select * from staff where 1=1";
            DataTable dt = SqliteHelper.GetList(sql);
            List<workInfo> list = new List<workInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new workInfo()
                {
                    W_id = row["w_id"].ToString(),
                    Wname = row["name"].ToString(),
                    Wage= (int)row["age"],
                    Wsex = row["sex"].ToString(),
                    Wdepartment_id = row["department_id"].ToString(),
                    Wpost = row["post"].ToString()

                });

            }
            return list;

        }

        public int Insert(workInfo wk)
        {
            string sql = "insert into staff(w_id,name,age,sex,department_id,post) values(@Id,@Name,@Age,@Sex,@Department_id,@Post)";
            List<SqlParameter> listP = new List<SqlParameter>();
            if (wk != null)
            {
                listP.Add(new SqlParameter("@Id", wk.W_id));  
                listP.Add(new SqlParameter("@Name", wk.Wname));
                listP.Add(new SqlParameter("@Age", wk.Wage));
                listP.Add(new SqlParameter("@Sex", wk.Wsex));
                listP.Add(new SqlParameter("@Department_id", wk.Wdepartment_id));  
                listP.Add(new SqlParameter("@Post", wk.Wpost));
            }
            return SqliteHelper.ExecuteNonQuery(sql, listP.ToArray());

        }

        public int Update(workInfo wk)
        {
            string sql = "update staff set name=@Name,age=@Age,sex=@Sex,department_id=@Department_id,post=@Post where w_id=@Id";

            SqlParameter[] ps =
            {
                new SqlParameter("@Id", wk.W_id),
                new SqlParameter("@Name", wk.Wname),
                new SqlParameter("@Age", wk.Wage),
                new SqlParameter("@Sex", wk.Wsex),
                new SqlParameter("@Department_id", wk.Wdepartment_id),
                new SqlParameter("@Post", wk.Wpost)
             };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(string id)
        {
            string sql = "delete from staff where w_id = @Id";
            SqlParameter p = new SqlParameter("@Id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);

        }
    }
}
