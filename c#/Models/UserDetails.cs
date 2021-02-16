using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDetails
    {
        public long Id { get; set; }
        public string childId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int userHMO { get; set; }
        public string token { get; set; }
        public Nullable<int> points { get; set; }
        public Nullable<int> snoozeCounter { get; set; }
        public Nullable<int> snoozePeriod { get; set; }

    }
}
