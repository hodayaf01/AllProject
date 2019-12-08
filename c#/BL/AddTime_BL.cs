using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AddTime_BL
    {
        TimeOfDay_DAL _TimeOfDay_DAL = new TimeOfDay_DAL();
        MedicinesDAL _medicinesDAL = new MedicinesDAL();
        KingOfDosageDAL _KingOfDosageDAL = new KingOfDosageDAL();
        MedicinesToChild_DAL _MedicinesToChild_DAL = new MedicinesToChild_DAL();
        TimeToMedicinesForChild_DAL _TimeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        public void Add(long userId,TimeOfDay _details)
        {
            _TimeOfDay_DAL.Add(_details);
            _medicinesDAL.Add();
            _KingOfDosageDAL.Add();
            _MedicinesToChild_DAL.Add(userId);
            
        }
    }
}
