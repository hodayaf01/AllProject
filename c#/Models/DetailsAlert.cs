using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DetailsAlert
    {
        public string UserToken { get; set; }
        public Snooze snooze { get; set; }
        public int AlertCount { get; set; }
        public string UserName { get; set; }
        public int CodeTime { get; set; }
        // public bool sendSMS { get; set; }
    }
}
