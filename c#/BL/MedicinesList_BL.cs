using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MedicinesList_BL
    {
        User_DAL _userDAL = new User_DAL();
        MedicinesToChild_DAL _medicinesToChild_DAL = new MedicinesToChild_DAL();
        TimeToMedicinesForChild_DAL _timeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        TimeOfDay_DAL _timeOfDay_DAL = new TimeOfDay_DAL();
        KingOfDosageDAL _kingOfDosageDAL = new KingOfDosageDAL();

        //שליפת רשימת התרופות לפי קוד ילד וקוד זמן ביום
        public List<GenerateMedicine> Get(CodeTimeToUser _details) {

            List<GenerateMedicine> _generateMedicinesList = new List<GenerateMedicine>();
            List< MedicinesToChild > _medicinesToChild = _medicinesToChild_DAL.GetByUser(_details.UserID);
            List< MedicinesToChild > _medicinesToChild = _medicinesToChild_DAL.GetByUserInSomeTime(_details);

            foreach (var _medicines in _medicinesToChild)
            {
                _medicines _generateMedicinesList.Add ( new GenerateMedicine
                {
                    MedicineName = _medicines.Medicine.midicineName,
                    DosageName =_medicines.KingOfDosage.kindOfDosageName,
                    Dosage=_medicines.Dosage
                });
            }
            return _generateMedicinesList;
            //for (int i = 0; i < medicinesToChild.Count; i++)
            //{
            //   List<TimeToMedicinesForChild> timeToMedicinesForChild= _timeToMedicinesForChild_DAL.GetByMedicineToChild(medicinesToChild[i].Id);
            //    for (int j = 0; j < timeToMedicinesForChild.Count; j++)
            //    {
            //        TimeOfDay timeOfDay = _timeOfDay_DAL.GetByTimeId(timeToMedicinesForChild[j].idTimeOfDay);
            //        if (timeOfDay.timeCode == _details.TimeOfDay)
            //        {
            //            KingOfDosage kingOfDosage = _kingOfDosageDAL.getByIdKindOfChild(medicinesToChild[i].kindOfDosage);
            //            GenerateMedicine generateMedicine = new GenerateMedicine();
            //            generateMedicine.MedicineName = medicinesToChild[i].Medicine.midicineName;
            //            generateMedicine.Dosage = medicinesToChild[i].Dosage;
            //            generateMedicine.DosageName = kingOfDosage.kindOfDosageName;
            //            generateMedicinesList.Add(generateMedicine);
            //        }
            //    }
            //}
        }
        //עדכון סטטוס התרופות לאחר שהמשתמש אישר שלקח אותם
        public static void Update(CodeTimeToUser details)
        {
            
        }
    }
}
