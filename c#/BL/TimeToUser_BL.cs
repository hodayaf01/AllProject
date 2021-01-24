using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TimeToUser_BL
    {
        MedicinesToChild_DAL _MedicinesToChild_DAL = new DAL.MedicinesToChild_DAL();
        TimeToMedicinesForChild_DAL _TimeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        TimeOfDay_DAL _TimeOfDay_DAL = new TimeOfDay_DAL();
    }
}
