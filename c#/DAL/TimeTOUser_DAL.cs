using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TimeTOUser_DAL
    {
        MediDBEntities _DB = new MediDBEntities();

        public List<TimeOfDay> Get(long userId)
        {

            //var medicinesToChilds = _DB.MedicinesToChilds.Where(m => m.userId == userId).ToList();
            // var timeOfDay= medicinesToChilds.Where(m=>m.)
            // var medicinesToChilds = _DB.TimeToMedicinesForChilds. MedicinesToChilds.Where(m => m.userId == userId).ToList().;
            // var = medicinesToChilds.Where(m => m.)
            //res = res == null ? null : res;
            //return res;
            return new List<TimeOfDay>();
        }
    }
}
