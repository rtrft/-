using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class absenceInfo
    {
        public string A_id { get; set; }
        public string A_name { get; set; }
        public string A_type{ get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string A_decision { get; set; }
    }
}
