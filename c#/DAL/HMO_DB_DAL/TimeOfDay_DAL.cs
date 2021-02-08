using Models;
using Models.HMO_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class TimeOfDay_DAL
    {
        HMO_DBEntities _DB = new HMO_DBEntities();

        //public List<TimeOfDay> Get()
        //{
        //    var res = _DB.TimeOfDays.ToList();
        //    res = res == null ? new List<TimeOfDay>() { new TimeOfDay() } : res;
        //    return res;
        //}

        //public void Add(TimeOfDay details)
        //{
        //    _DB.TimeOfDays.Add(details);
        //    _DB.SaveChanges();
        //}

        //public void Edit(TimeOfDay details)
        //{
        //    _DB.Entry(details);
        //    _DB.SaveChanges();
        //}
    }
}
