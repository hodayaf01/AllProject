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
        public void Add(TimeOfDay details)
        {
            _DB.TimeOfDays.Add(details);
            _DB.SaveChanges();
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
