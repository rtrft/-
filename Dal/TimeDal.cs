using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Dal
{
    public class TimeDal
    {
        public int Update(TimeInfo ti)
        {
            string sql = "update Time set Time1=@Time1,Time2=@Time2,Time3=@Time3,Time4=@Time4";

            SqlParameter[] ps =
            {
                new SqlParameter("@Time1", ti.Time1),
                new SqlParameter("@Time2", ti.Time2),
                new SqlParameter("@Time3", ti.Time3),
                new SqlParameter("@Time4", ti.Time4),
             };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
