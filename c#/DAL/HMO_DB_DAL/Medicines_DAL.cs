﻿using Models;
using Models.HMO_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class Medicines_DAL
    {
        HMO_DBEntities _DB = new HMO_DBEntities();

        public List<Models.HMO_db.Medicine> Get()
        {
            var res = _DB.Medicines.ToList();
            res = res == null ? new List<Models.HMO_db.Medicine> () : res;
            return res;
        }
    }
}
