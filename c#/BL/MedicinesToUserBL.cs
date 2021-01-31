using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MedicinesToUserBL
    {
        public MedicinesDAL _medicinesDAL = new MedicinesDAL();

        public List<GenerateMedicine> Get(CodeTimeToUser t)
        {
            List<GenerateMedicine> temp = new List<GenerateMedicine>();
            return temp;
            //return _medicinesDAL.Get();
        }

        public void AddOrEdit(Medicine details)
        {
            if (details.medicineId == 0)
            {
                _medicinesDAL.Add();
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

        public static void Update(CodeTimeToUser details)
        {
            throw new NotImplementedException();
        }
    }
}
