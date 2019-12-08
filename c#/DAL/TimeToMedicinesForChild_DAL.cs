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
      //  DAL.HMO_DB_DAL.

        public void Add(TimeToMedicinesForChild details)
        {
            _DB.TimeToMedicinesForChilds.Add(details);
            _DB.SaveChanges();
        }

        public TimeToMedicinesForChild Get()
        {
            var res = _DB.TimeToMedicinesForChilds.ToList().FirstOrDefault();
            res = res == null ? new TimeToMedicinesForChild() : res;
            return res;
        }       

        public void Edit(TimeToMedicinesForChild details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
