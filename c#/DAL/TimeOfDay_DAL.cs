using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TimeOfDay_DAL
    {
        MediDBEntities _DB = new MediDBEntities();
        public bool Add(TimeOfDay details)
        {
            _DB.TimeOfDays.Add(details);           
            if (_DB.SaveChanges() == 0)
                return false;
            return true;
        }

        public TimeOfDay Get()
        {
            var res = _DB.TimeOfDays.ToList().FirstOrDefault();
            res = res == null ? new TimeOfDay() : res;
            return res;
        }

        public void Edit(TimeOfDay details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
