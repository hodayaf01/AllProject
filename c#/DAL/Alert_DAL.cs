using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Alert_DAL
    {
        MediDBEntities _DB = new MediDBEntities();
        public TimeOfDay Get(int timeCode)
        {
            var res = _DB.TimeOfDays.ToList().FirstOrDefault(t=>t.timeCode==timeCode);
            res = res == null ? new TimeOfDay() : res;
            return res;
        }
    }
}
