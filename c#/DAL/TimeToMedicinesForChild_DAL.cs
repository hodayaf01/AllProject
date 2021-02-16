using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TimeToMedicinesForChild_DAL
    {
        MediDBEntities _DB = new MediDBEntities();
        public long Add(TimeToMedicinesForChild details)
        {
            _DB.TimeToMedicinesForChilds.Add(details);
            _DB.SaveChanges();
            return details.Id;
        }

        public TimeToMedicinesForChild Get()
        {
            var res = _DB.TimeToMedicinesForChilds.ToList().FirstOrDefault();
            res = res == null ? new TimeToMedicinesForChild() : res;
            return res;
        }
        //public TimeToMedicinesForChild TakeToDay()
        //{
        //    var res = _DB.TimeToMedicinesForChilds.ToList().FirstOrDefault(t=>t.MedicinesToChild.date==DateTime.Today);
        //    res = res == null ? new TimeToMedicinesForChild() : res;
        //    return res;
        //}

        public List<TimeToMedicinesForChild> GetByMedicineToChild(long userId) {
            var res = _DB.TimeToMedicinesForChilds.Where(t => (t.MedicinesToChild.userId ==userId)).ToList();
            res = res == null ? null : res;
            return res;
        } 
        public List<TimeToMedicinesForChild> GetByMedicineToChildToDay(long userId) {
            var res = _DB.TimeToMedicinesForChilds.Where(t => (t.MedicinesToChild.userId ==userId)&& t.MedicinesToChild.date == DateTime.Today).ToList();
            res = res == null ? null : res;
            return res;
        }
        public List<TimeToMedicinesForChild> GetByMedicineToChildToDay(long userId,int timeCode) {
            var res = _DB.TimeToMedicinesForChilds.Where(t => (t.MedicinesToChild.userId ==userId)&& (t.MedicinesToChild.date == DateTime.Today)&&(t.TimeOfDay.timeCode==timeCode)).ToList();
            //res = res == null ? null : res;
            res = res == null ? new List<TimeToMedicinesForChild>() : res;
            return res;
        }

        public void Edit(TimeToMedicinesForChild details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }

    }
}
