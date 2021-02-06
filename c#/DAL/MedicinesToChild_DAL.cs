using DAL.HMO_DB_DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicinesToChild_DAL
    {
        MediDBEntities _DB = new MediDBEntities();
        MedicinesToClient_DAL _MedicinesToClient_DAL = new HMO_DB_DAL.MedicinesToClient_DAL();
        //TimeToMedicinesForChild _TimeToMedicinesForChild = new TimeToMedicinesForChild();
        HMO_DB_DAL.TimeOfDay_DAL _timeOfDay_DAL = new HMO_DB_DAL.TimeOfDay_DAL();
        TimeToMedicinesForClient_DAL _timeToMedicinesForClient_DAL = new TimeToMedicinesForClient_DAL();
        public MedicinesToChild Get()
        {
            var res = _DB.MedicinesToChilds.ToList().FirstOrDefault();
            res = res == null ? new MedicinesToChild() : res;
            return res;
        }

        //public bool AddListMedicinesToUser(long userId, List<TimeOfDay> listTimeOfDays)
        public bool AddListMedicinesToUser(TimeOfAlertForUser timeOfAlertForUser)
        {
            //List<MedicinesToClient> medicinesToClients = _MedicinesToClient_DAL.Get(token);
            List<MedicinesToClient> medicinesToClients = _MedicinesToClient_DAL.Get(timeOfAlertForUser.snooze.userId);

            foreach (var item in medicinesToClients)
            {
                //_DB.Medicines.Add(new Medicine() { medicineId = item.medicineId, midicineName = item.midicineName });
                MedicinesToChild medicinesToChild = new MedicinesToChild()
                {
                    medicineId = item.medicinesId,
                    userId = timeOfAlertForUser.snooze.userId,
                    kindOfDosage = item.kindOfDosage,
                    Dosage = item.Dosage,
                };
                _DB.MedicinesToChilds.Add(medicinesToChild);

                //List<> _timeOfDay_DAL.Get().TimeToMedicinesForC.Where(t=>t.)
              
                List<TimeToMedicinesForClient> timesToMedicine = _timeToMedicinesForClient_DAL.GetTimeOfDaysByTimeMidicineToClient(medicinesToChild.Id);
                foreach (var timeList in timesToMedicine)
                {

                    _DB.TimeToMedicinesForChilds.Add(new TimeToMedicinesForChild()
                    {
                        idMedicineToChild = medicinesToChild.Id,
                        //idTimeOfDay = listTimeOfDays.Find(t => t.timeCode == item.TimeToMedicinesForClients.Where(tC => tC.TimeOfDay.timeId)).timeId
                        idTimeOfDay = timeOfAlertForUser.timeOfDay.Find(t => t.timeCode == timeList.timeCode).timeId
                    });
                }
                // int codeTimeToClient = item.TimeToMedicinesForClients.FirstOrDefault(t=>t.TimeOfDay.timeCode)
               
            }
            if (_DB.SaveChanges() == 0)
                return false;
            return true;
        }

        public List<MedicinesToChild> GetByUser(long id)
        {
            var res = _DB.MedicinesToChilds.Where(m => m.userId == id).ToList();
            res = res == null ? null : res;


           // _DB.Users.FirstOrDefault(i => i.childId == "").MedicinesToChilds.SelectMany(t => t.TimeToMedicinesForChilds);
            return res;
        }

        public List<MedicinesToChild> GetByUserInSomeTime(CodeTimeToUser details)
        {
            var res = _DB.MedicinesToChilds.Where(m => m.userId == details.UserID && m.TimeToMedicinesForChilds.All(t=>t.TimeOfDay.timeCode==details.TimeOfDay)==true).ToList();

            //foreach (var item in res)
            //{
            //    _DB.TimeToMedicinesForChilds.Where(m=>m.idMedicineToChild==item.Id).ToList()
            //}
            //!!!!!!!!!!!!!!!!
            // res.FindAll(m=>m.TimeToMedicinesForChilds)
           // res = res == null ? null : res;


           // _DB.Users.FirstOrDefault(i => i.childId == "").MedicinesToChilds.SelectMany(t => t.TimeToMedicinesForChilds);
            return res;
        }

       
       
        public void Edit(MedicinesToChild details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
