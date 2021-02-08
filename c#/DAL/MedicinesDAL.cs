using DAL.HMO_DB_DAL;
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
        //HMO_DBEntities _HMO_DB = new HMO_DBEntities();
        Medicines_DAL _MedicinesInHMO_DAL = new HMO_DB_DAL.Medicines_DAL();
        //public void Add()
        //{
        //    List<Medicine> medicines = _MedicinesInHMO_DAL.Get();
        //    foreach (var item in medicines)
        //    {
        //        _DB.Medicines.Add(new Medicine() { medicineId= item.medicineId, midicineName=item.midicineName});
        //    }           
        //    _DB.SaveChanges();
        //}

        public Medicine Get()
        {
            var res = _DB.Medicines.ToList().FirstOrDefault();
            res = res == null ? new Medicine() : res;
            return res;
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
