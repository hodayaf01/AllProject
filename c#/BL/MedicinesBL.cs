using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MedicinesBL
    {
        public MedicinesDAL _medicinesDAL = new MedicinesDAL();

        public Medicine Get()
        {
            return _medicinesDAL.Get();
        }

        public void AddOrEdit(Medicine details)
        {
            if (details.medicineId == 0)
            {
                _medicinesDAL.Add(details);
            }
            else
            {
                _medicinesDAL.Edit(details);
            }
        }

        public void Delete()
        {
            _medicinesDAL.Delete();
        }       
    }
}
