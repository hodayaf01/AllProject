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
        MedicinesToChild_DAL _medicinesToChild_DAL = new MedicinesToChild_DAL();
        TimeToMedicinesForChild_DAL _TimeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        public MedicinesDAL _medicinesDAL = new MedicinesDAL();
        ArchiveDAL _archiveDAL = new ArchiveDAL();
        TimeOfDay_DAL _TimeOfDay_DAL = new TimeOfDay_DAL();
        User_DAL _User_DAL = new User_DAL();
        //Alert_BL _alert_BL = new Alert_BL();

        //שליפת רשימת התרופות לפי קוד ילד וקוד זמן ביום
        public List<GenerateMedicine> Get(CodeTimeToUser _details)
        {

            List<GenerateMedicine> _generateMedicinesList = new List<GenerateMedicine>();
            //List< MedicinesToChild > _medicinesToChild = _medicinesToChild_DAL.GetByUser(_details.UserID);
            List<MedicinesToChild> _medicinesToChild = _medicinesToChild_DAL.GetByUserInSomeTime(_details);

            foreach (var _medicines in _medicinesToChild)
            {
                _generateMedicinesList.Add(new GenerateMedicine
                {
                    MedicineName = _medicines.Medicine.midicineName,
                    DosageName = _medicines.KingOfDosage.kindOfDosageName,
                    Dosage = _medicines.Dosage,
                    Id = _medicines.Id,
                    Points = _medicines.User.points == null ? 0 : (int)(_medicines.User.points),
                    Time = _medicines.TimeToMedicinesForChilds.FirstOrDefault(m => m.TimeOfDay.timeCode == _details.TimeOfDay).TimeOfDay.theTime,
                    Status = _medicines.TimeToMedicinesForChilds.FirstOrDefault(m => m.TimeOfDay.timeCode == _details.TimeOfDay).status == null ? false : (bool)_medicines.TimeToMedicinesForChilds.FirstOrDefault(m => m.TimeOfDay.timeCode == _details.TimeOfDay).status
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

        public void Update(UpdateListMedicines _details)
        {
            //עדכון סטטוס התרופות לאחר שהמשתמש אישר שלקח אותם
            List<MedicinesToChild> _medicinesToChild = _medicinesToChild_DAL.GetByUserInSomeTime(_details.CodeTimeToUser);
            List<ArchiveTakeMedicine> archives = _archiveDAL.GetToDay(_details.CodeTimeToUser.UserID);
            foreach (var _medicines in _medicinesToChild)
            {
                if (_details.ListMedicines.Find(m => m.Id == _medicines.Id).Status)
                {
                    TimeToMedicinesForChild timeToMedicinesForChild = _medicines.TimeToMedicinesForChilds.First(m => m.TimeOfDay.timeCode == _details.CodeTimeToUser.TimeOfDay);
                    timeToMedicinesForChild.status = true;
                    _TimeToMedicinesForChild_DAL.Edit(timeToMedicinesForChild);
                    ArchiveTakeMedicine archiveTake= archives.Find(a=>a.medicineToChild==timeToMedicinesForChild.Id);
                    archiveTake.time = DateTime.Now.TimeOfDay;
                    //archiveTake.onTime = !(_details.CountSnooze > timeToMedicinesForChild.MedicinesToChild.User.snoozeCounter);
                    User user = _User_DAL.GetByIdentity(_details.CodeTimeToUser.UserID);
                    int maxMinute = (int)user.snoozePeriod * (int)user.snoozeCounter;
                    TimeSpan temp = new TimeSpan(0, maxMinute, 0);
                    TimeSpan maxTime = timeToMedicinesForChild.TimeOfDay.theTime.Add(temp);
                    temp = DateTime.Now.TimeOfDay;
                    //if (_details.CountSnooze <= timeToMedicinesForChild.MedicinesToChild.User.snoozeCounter / 2)
                    if (maxTime >= DateTime.Now.TimeOfDay)
                    {
                        temp = timeToMedicinesForChild.TimeOfDay.theTime;
                        int count = 0;
                        bool flag = true;
                        while (flag)
                        {
                            temp.Add(new TimeSpan(0, (int)user.snoozePeriod, 0));
                            count++;
                            if (temp >= DateTime.Now.TimeOfDay)
                                flag = false;
                        }
                        if (count <= timeToMedicinesForChild.MedicinesToChild.User.snoozeCounter / 2) user.points += 2;
                        //if(temp <= timeToMedicinesForChild.TimeOfDay.theTime.Add(new TimeSpan(0,(int)timeToMedicinesForChild.MedicinesToChild.User.snoozeCounter / 2* (int)timeToMedicinesForChild.MedicinesToChild.User.snoozePeriod,0)))
                        else user.points += 1;
                        archiveTake.onTime = true;
                        //למחוק מההתראות
                        Alert_BL.RemoveSnooze(_details.CodeTimeToUser);
                    }
                    else archiveTake.onTime = false;
                    //else if (_details.CountSnooze <= timeToMedicinesForChild.MedicinesToChild.User.snoozeCounter)
                    _User_DAL.Edit(user);
                    _archiveDAL.Edit(archiveTake);


                }
            }

        }
    }
}
