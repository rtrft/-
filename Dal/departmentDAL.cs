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
    public class departmentDAL
    {
        public List<departmentInfo> GetList(string id,string name)
        {
            string sql = "select * from department where D_id=@Id or D_name=@Name";
            SqlParameter[] ps =
           {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", name),
             };
            DataTable dt = SqliteHelper.GetList(sql, ps);
            List<departmentInfo> list = new List<departmentInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new departmentInfo()
                {
                    D_id = row["D_id"].ToString(),
                    D_name = row["D_name"].ToString(),
                    D_Load = row["D_Load"].ToString(),
                    D_place = row["D_place"].ToString()

                });

            }
            return list;

        }


        public List<departmentInfo> GetList2()
        {
            string sql = "select * from department where 1=1";
            DataTable dt = SqliteHelper.GetList(sql);
            List<departmentInfo> list = new List<departmentInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new departmentInfo()
                {
                    D_id = row["D_id"].ToString(),
                    D_name = row["D_name"].ToString(),
                    D_Load = row["D_Load"].ToString(),
                    D_place = row["D_place"].ToString()
                });

            }
            return list;

        }

        public int Insert(departmentInfo dp)
        {
            string sql = "insert into department(D_id,D_name,D_Load,D_place) values(@Id,@Name,@Load,@Place)";
            List<SqlParameter> listP = new List<SqlParameter>();
            if (dp != null)
            {
                listP.Add(new SqlParameter("@Id", dp.D_id));
                listP.Add(new SqlParameter("@Name", dp.D_name));
                listP.Add(new SqlParameter("@Load", dp.D_Load));
                listP.Add(new SqlParameter("@Place", dp.D_place));
            }
            return SqliteHelper.ExecuteNonQuery(sql, listP.ToArray());

        }

        public int Update(departmentInfo dp)
        {
            string sql = "update department set D_name=@Name,D_Load=@Load,D_place=@Place where D_id=@Id";

            SqlParameter[] ps =
            {
                new SqlParameter("@Id", dp.D_id),
                new SqlParameter("@Name", dp.D_name),
                new SqlParameter("@Load", dp.D_Load),
                new SqlParameter("@Place", dp.D_place),
             };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(string id)
        {
            string sql = "delete from department where D_id = @Id";
            SqlParameter p = new SqlParameter("@Id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);

        }
    }
}
