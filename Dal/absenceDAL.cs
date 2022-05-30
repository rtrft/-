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
    public class absenceDAL
    {
        public List<absenceInfo> GetList(string id,string name)
        {
            string sql = "select * from absence where A_id=@Id or A_name=@Name";
            SqlParameter[] ps =
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", name),
             };
            DataTable dt = SqliteHelper.GetList(sql, ps);
            List<absenceInfo> list = new List<absenceInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new absenceInfo()
                {
                    A_id = row["A_id"].ToString(),
                    A_name = row["A_name"].ToString(),
                    A_type = row["A_type"].ToString(),
                    Start_time = (DateTime)row["Start_time"],
                    End_time = (DateTime)row["End_time"],
                    A_decision = row["decision"].ToString()

                });

            }
            return list;

        }



        public List<absenceInfo> GetList2()
        {
            string sql = "select * from absence where 1=1";
            DataTable dt = SqliteHelper.GetList(sql);
            List<absenceInfo> list = new List<absenceInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new absenceInfo()
                {
                    A_id = row["A_id"].ToString(),
                    A_name = row["A_name"].ToString(),
                    A_type = row["A_type"].ToString(),
                    Start_time = (DateTime)row["Start_time"],
                    End_time = (DateTime)row["End_time"],
                    A_decision = row["decision"].ToString()

                });

            }
            return list;

        }

        public List<absenceInfo> GetList3(string name,string type)
        {
            string sql = "select * from absence where A_id=@Name and A_type=@Type";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@Name", name),new SqlParameter("@Type", type)};
            DataTable dt = SqliteHelper.GetList(sql, p);
            List<absenceInfo> list = new List<absenceInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new absenceInfo()
                {
                    A_id = row["A_id"].ToString(),
                    A_name = row["A_name"].ToString(),
                    A_type = row["A_type"].ToString(),
                    Start_time=(DateTime)row["Start_time"],
                    End_time = (DateTime)row["End_time"],
                    A_decision = row["decision"].ToString()

                });

            }
            return list;

        }

        public int Insert(absenceInfo dp)
        {
            string sql = "insert into absence(A_id,A_name,A_type,Start_time,End_time) values(@Id,@Name,@Type,@Start_time,@End_time)";
            List<SqlParameter> listP = new List<SqlParameter>();
            if (dp != null)
            {
                listP.Add(new SqlParameter("@Id", dp.A_id));
                listP.Add(new SqlParameter("@Name", dp.A_name));
                listP.Add(new SqlParameter("@Type", dp.A_type));
                listP.Add(new SqlParameter("@Start_time", dp.Start_time));
                listP.Add(new SqlParameter("@End_time", dp.End_time));
            }
            return SqliteHelper.ExecuteNonQuery(sql, listP.ToArray());

        }

        public int Update(absenceInfo ab)
        {
            string sql = "update absence set decision=@Decision where A_id=@Id";

            SqlParameter[] ps =
            {
                new SqlParameter("@Id", ab.A_id),
                new SqlParameter("@Decision", ab.A_decision)
             };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update2(absenceInfo ab)
        {
            string sql = "update absence set A_type=@Type,Start_time=@Start_time,End_time=@End_time where A_name=@Name";

            SqlParameter[] ps =
            {
                new SqlParameter("@Name", ab.A_name),
                new SqlParameter("@Type", ab.A_type),
                new SqlParameter("@Start_time", ab.Start_time),
                new SqlParameter("@End_time", ab.End_time)
             };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(string name)
        {
            string sql = "delete from absence where A_name = @Name";
            SqlParameter p = new SqlParameter("@Name", name);
            return SqliteHelper.ExecuteNonQuery(sql, p);

        }

    }
}
