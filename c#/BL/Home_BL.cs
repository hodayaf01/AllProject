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
        KingOfDosageDAL _kingOfDosageDAL = new KingOfDosageDAL();

        public List<GenerateMedicine> Get(CodeTimeToUser _details) {

            List<GenerateMedicine> generateMedicinesList = new List<GenerateMedicine>();
            List< MedicinesToChild > medicinesToChild = _medicinesToChild_DAL.GetByUser(_details.UserID);

            for (int i = 0; i < medicinesToChild.Count; i++)
            {
               List<TimeToMedicinesForChild> timeToMedicinesForChild= _timeToMedicinesForChild_DAL.GetByMedicineToChild(medicinesToChild[i].Id);
                for (int j = 0; j < timeToMedicinesForChild.Count; j++)
                {
                    TimeOfDay timeOfDay = _timeOfDay_DAL.GetByTimeId(timeToMedicinesForChild[j].idTimeOfDay);
                    if (timeOfDay.timeCode == _details.TimeOfDay)
                    {
                        KingOfDosage kingOfDosage = _kingOfDosageDAL.getByIdKindOfChild(medicinesToChild[i].kindOfDosage);
                        GenerateMedicine generateMedicine = new GenerateMedicine();
                        //generateMedicine.MedicineName = medicinesToChild[i].name;
                        generateMedicine.Dosage = medicinesToChild[i].Dosage;
                        generateMedicine.DosageName = kingOfDosage.kindOfDosageName;
                        //generateMedicine.Id = ?
                        generateMedicinesList.Add(generateMedicine);
                    }
                }

            }
            

            return generateMedicinesList;
        }
    }
}
