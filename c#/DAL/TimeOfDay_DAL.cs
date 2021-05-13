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
        ////public long Add(TimeOfDay details)
        //public bool Add(TimeOfDay details)
        //{
        //    _DB.TimeOfDays.Add(details);
        //    if (_DB.SaveChanges() == 0)
        //        return false;
        //    //return 0;
        //    // return details.timeId;
        //    return true;
        //}

        public bool AddListTimeOfAlert(List<TimeOfDay> _details)
        {
            foreach (var time in _details)
            {
                
                _DB.TimeOfDays.Add(time);
            }
            if (_DB.SaveChanges() == 0)
                return false;
            return true;
        }
        //public Array<long> add

        public TimeOfDay Get()
        {
            var res = _DB.TimeOfDays.ToList().FirstOrDefault();
            res = res == null ? new TimeOfDay() : res;
            return res;
        }
        public List<TimeOfDay> GetAll()
        {
            var res = _DB.TimeOfDays.ToList();
            res = res == null ? new List<TimeOfDay>() : res;
            return res;
        }

        public TimeOfDay GetByTimeId(long idTimeOfDay)
        {
            var res = _DB.TimeOfDays.FirstOrDefault(t => t.timeId == idTimeOfDay);
            res = res == null ? null : res;
            return res;
        }

        public List<TimeOfDay> GetListByUserId(long userId)
        {
            List<TimeOfDay> timeOfDays = _DB.TimeOfDays.Where(t => t.userId == userId).ToList();
            timeOfDays = timeOfDays == null ? null : timeOfDays;
            return timeOfDays;
        }
        public void Edit(TimeOfDay details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }


    }
}
