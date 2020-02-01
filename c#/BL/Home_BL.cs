using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Home_BL
    {
        User_DAL _userDAL = new User_DAL();
        MedicinesToChild_DAL _medicinesToChild_DAL = new MedicinesToChild_DAL();
        TimeToMedicinesForChild_DAL _timeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        TimeOfDay_DAL _timeOfDay_DAL = new TimeOfDay_DAL();
        public List<GenerateMedicine> Get(Home _details) {

            List<GenerateMedicine> generateMedicinesList = new List<GenerateMedicine>();

            List< MedicinesToChild > medicinesToChild = _medicinesToChild_DAL.GetByUser(_details.UserID);
            

            return generateMedicinesList;
        }
    }
}
