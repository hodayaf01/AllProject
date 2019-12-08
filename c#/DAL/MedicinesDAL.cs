using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicinesDAL
    {
        MediDBEntities _DB = new MediDBEntities();

        public Medicine Get()
        {
            var res = _DB.Medicines.ToList().FirstOrDefault();
            res = res == null ? new Medicine() : res;
            return res;
        }

        public void Add(Medicine details)
        {
            _DB.Medicines.Add(details);
            _DB.SaveChanges();
        }

        public void Edit(Medicine details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
        public void Delete()
        {
            //_DB.Medicines.First().DeleteRow = false;
        }
    }
}
