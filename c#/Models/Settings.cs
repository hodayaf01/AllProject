using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Settings
    {
        private Settings settings;

        public User User { get; set; }
        public List<Guardian> Guardians { get; set; }
        public List<TimeOfDay> TimeOfDays { get; set; }
    }
}
