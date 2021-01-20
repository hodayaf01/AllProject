using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TimeToUser
    {
        public long UserID { get; set; }
        public List<TimeSpan> Times { get; set; }
        //public int Hour { get; set; }
        //public int  Minute { get; set; }
       
    }
}
