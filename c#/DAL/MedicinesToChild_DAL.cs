using DAL.HMO_DB_DAL;
using Models;
using Models.HMO_db;
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
        HMO_DB_DAL.TimeOfDay_DAL _timeOfDay_DAL = new HMO_DB_DAL.TimeOfDay_DAL();
        TimeToMedicinesForClient_DAL _timeToMedicinesForClient_DAL = new TimeToMedicinesForClient_DAL();
        TimeToMedicinesForChild_DAL _timeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        TimeOfDay_DAL _TimeOfDay_DAL = new TimeOfDay_DAL();
       // MedicinesToChild_DAL _MedicinesToChild_DAL = new MedicinesToChild_DAL();

        User_DAL _User_DAL = new User_DAL();
        public MedicinesToChild Get()
        {
            var res = _DB.MedicinesToChilds.ToList().FirstOrDefault();
            res = res == null ? new MedicinesToChild() : res;
            return res;
        }

        //public bool AddListMedicinesToUser(long userId, List<TimeOfDay> listTimeOfDays)
        //public List<DetailsAlert>[] AddListMedicinesToUser(TimeOfAlertForUser timeOfAlertForUser)
        public bool AddListMedicinesToUser(TimeOfAlertForUser timeOfAlertForUser)
        {
            //V
            // List<DetailsAlert>[] _DetailsOfAlert = new List<DetailsAlert>[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    _DetailsOfAlert[i] = new List<DetailsAlert>();

            //}
            List<Models.HMO_db.MedicinesToClient> medicinesToClients = _MedicinesToClient_DAL.GetByUserId(timeOfAlertForUser.snooze.userId);

            if (medicinesToClients.Count() != 0)
            {
                foreach (var item in medicinesToClients)
                {
                    //_DB.Medicines.Add(new Medicine() { medicineId = item.medicineId, midicineName = item.midicineName });
                    MedicinesToChild medicinesToChild = new MedicinesToChild()
                    {
                        medicineId = item.medicinesId,
                        userId = timeOfAlertForUser.snooze.userId,
                        kindOfDosage = item.kindOfDosage,
                        Dosage = item.Dosage,
                        date=DateTime.Today
                    };
                    long medicinesToChildId = Add(medicinesToChild);//V


                    //V
                    List<TimeToMedicinesForClient> timesToMedicine = _timeToMedicinesForClient_DAL.GetTimeOfDaysByTimeMidicineToClient(item.Id);
                    if (timesToMedicine.Count() != 0)
                    {
                        foreach (var timeList in timesToMedicine)
                        {
                            TimeToMedicinesForChild timeToMedicinesForChild = new TimeToMedicinesForChild()
                            {
                                idMedicineToChild = medicinesToChildId,
                                //idTimeOfDay = listTimeOfDays.Find(t => t.timeCode == item.TimeToMedicinesForClients.Where(tC => tC.TimeOfDay.timeId)).timeId
                                idTimeOfDay = timeOfAlertForUser.timeOfDay.Find(t => t.timeCode == timeList.timeCode).timeId
                            };
                            _timeToMedicinesForChild_DAL.Add(timeToMedicinesForChild);

                            //User user = _User_DAL.GetByIdentity(timeOfAlertForUser.snooze.userId);
                            //DetailsAlert detailsAlert = new DetailsAlert()
                            //{
                            //    UserToken = user.token,
                            //    AlertCount = 0,
                            //    UserName = user.userName,
                            //    snooze = new Snooze
                            //    {
                            //        userId = user.Id,
                            //        snoozePeriod = (int)user.snoozePeriod,
                            //        snoozeCounter = (int)user.snoozeCounter.Value,
                            //    },
                            //    CodeTime = timeList.timeCode
                            //};
                            //_DetailsOfAlert[timeList.timeCode - 1].Add(detailsAlert);
                        }
                        // int codeTimeToClient = item.TimeToMedicinesForClients.FirstOrDefault(t=>t.TimeOfDay.timeCode)

                    }
                }
             

            }
            else if (_DB.SaveChanges() == 0)
                return false ;
            return true;
        }

        public long Add(MedicinesToChild medicinesToChild)
        {
            _DB.MedicinesToChilds.Add(medicinesToChild);
            _DB.SaveChanges();
            return medicinesToChild.Id;

        }

        public bool UpdateMedicincesToUsersEveryDay()
        {
            List<User> users = _DB.Users.ToList();

            foreach (var user in users)
            {
                List<TimeOfDay> timesToMedicine = _TimeOfDay_DAL.GetListByUserId(user.Id);
                if (timesToMedicine.Count() != 0)
                {
                    List<Models.HMO_db.MedicinesToClient> medicinesToClients = _MedicinesToClient_DAL.GetByUserId(user.Id);
                    ArchiveDAL _archiveDAL = new ArchiveDAL();
                    if (medicinesToClients.Count != 0)
                    {
                        foreach (var item in medicinesToClients)
                        {
                            MedicinesToChild medicinesToChild = new MedicinesToChild()
                            {
                                medicineId = item.medicinesId,
                                userId = user.Id,
                                kindOfDosage = item.kindOfDosage,
                                Dosage = item.Dosage,
                                date = DateTime.Today
                            };
                            long medicinesToChildId = Add(medicinesToChild);


                            //עבור כל תרופה לילד להכניס לזמן לילד
                            //שליפה מזמנים לילד והצבה עם זמנים לקליינט
                            foreach (var timeToMed in item.TimeToMedicinesForClients)
                            {

                                TimeToMedicinesForChild timeToChild = new TimeToMedicinesForChild()
                                {
                                    idMedicineToChild = medicinesToChildId,
                                    idTimeOfDay = timesToMedicine.First(t => t.timeCode == timeToMed.timeCode).timeId,//לבדוק
                                    status = false
                                };

                                //_DB.TimeToMedicinesForChilds.Add(timeToChild);
                                long timeToMedicinesForChildId = _timeToMedicinesForChild_DAL.Add(timeToChild);
                                _archiveDAL.Add(
                   new ArchiveTakeMedicine
                   {
                       userId = user.Id,
                       medicineToChild = timeToMedicinesForChildId,
                       date = DateTime.Now.Date,
                       onTime=false
                   });
                            }


                        }
                    }
                }

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
            //List<MedicinesToChild> res = _DB.MedicinesToChilds.Where(m => m.userId == details.UserID && m.TimeToMedicinesForChilds.All(t=>t.TimeOfDay.timeCode==details.TimeOfDay)).ToList();
            //List<MedicinesToChild> res = _DB.MedicinesToChilds.Where(m => m.userId == details.UserID&&m.TimeToMedicinesForChilds.All(t=>t.status==false)).ToList();
            List<MedicinesToChild> res = _DB.MedicinesToChilds.Where(m => (m.userId == details.UserID)&& m.date==DateTime.Today).ToList();

            List<MedicinesToChild> res2 = new List<MedicinesToChild>();
            foreach (var item in res)
            {
                foreach (var time in item.TimeToMedicinesForChilds)

            //    foreach (var time in _DB.TimeToMedicinesForChilds.Where(t=>t.idMedicineToChild==item.Id))
                {
                    if (time.TimeOfDay.timeCode == details.TimeOfDay)
                        res2.Add(item);
                }        
            }

            //foreach (var item in res)
            //{
            //    _DB.TimeToMedicinesForChilds.Where(m=>m.idMedicineToChild==item.Id).ToList()
            //}
            //!!!!!!!!!!!!!!!!
            // res.FindAll(m=>m.TimeToMedicinesForChilds)
           // res = res == null ? null : res;


           // _DB.Users.FirstOrDefault(i => i.childId == "").MedicinesToChilds.SelectMany(t => t.TimeToMedicinesForChilds);
            return res2;
        }

      
        public void Edit(MedicinesToChild details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
