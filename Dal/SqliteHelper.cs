using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace Dal
{
    class SqliteHelper
    {

        private static string conStr = ConfigurationManager.ConnectionStrings["cater"].ConnectionString;

        public static DataTable GetList(string sql, params SqlParameter[] ps)
        {

            //根据连接字符串创建连接对象
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(ps);

                DataTable dt = new DataTable();

                adapter.Fill(dt);//将数据库中的数据填充到dt中
                return dt;
            }
        }
        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteScalar();
            }

        }

    }
}
