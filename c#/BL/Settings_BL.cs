using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Settings_BL
    {
        User_DAL _userDAL = new User_DAL();
        GuardiansDAL _guardiansDAL = new GuardiansDAL();
        GurdiansToUser_DAL _gurdiansToUser_DAL = new GurdiansToUser_DAL();
        MedicinesToChild_DAL _medicinesToChild_DAL = new MedicinesToChild_DAL();
        TimeToMedicinesForChild_DAL _timeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
        TimeOfDay_DAL _timeOfDay_DAL = new TimeOfDay_DAL();

        public bool Edit(Settings _details)
        {   
            try
            {
                User user = _userDAL.GetById(_details.User.childId);
                if (user != null)
                {
                    if (_details.User.userName != null) { user.userName = _details.User.userName; }
                    if (_details.User.email != null) { user.email = _details.User.email; }
                    if (_details.User.password != null) { user.password = _details.User.password; }
                    _userDAL.Edit(user);
                }
                else return false;

                //guardian for spesific user
                List<guardiansToUser> guardiansToUser = _gurdiansToUser_DAL.GetByUser(user.Id);
                if (guardiansToUser.Count != 0)
                {
                    for (int i = 0; i < _details.Guardians.Count; i++)
                    {
                        if (guardiansToUser.FirstOrDefault(g => g.Id == _details.Guardians[i].Id) != null)//if guardian exist in DB
                        {
                            //map
                            Guardian guardianToMap = _guardiansDAL.Get(_details.Guardians[i].Id);
                            guardianToMap.guardianName = _details.Guardians[i].guardianName;
                            guardianToMap.PhoneNumber = _details.Guardians[i].PhoneNumber;
                            _guardiansDAL.Edit(guardianToMap);
                        }
                        else
                        {
                            //add
                            Guardian guardianToAdd = new Guardian();
                            guardianToAdd.PhoneNumber = _details.Guardians[i].PhoneNumber;
                            guardianToAdd.guardianName = _details.Guardians[i].guardianName;
                            long guardianID = _guardiansDAL.Add(guardianToAdd);
                            _gurdiansToUser_DAL.Add(new Models.guardiansToUser { guardianId = guardianID, userId = user.Id });

                        }
                    }
                }

                else return false;

                //map time for madicine
                List<MedicinesToChild> medicinesToChildList = _medicinesToChild_DAL.GetByUser(user.Id);
                for (int i = 0; i < medicinesToChildList.Count; i++)
                {
                    List<TimeToMedicinesForChild> timeToMedicinesForChildrenList = _timeToMedicinesForChild_DAL.GetByMedicineToChild(medicinesToChildList[i].Id);
                    var timeToMedicinesForChildrenListgroup = timeToMedicinesForChildrenList.GroupBy(t => t.idTimeOfDay).Select(t=>t.ToList()).ToList();
                    for (int key = 0; key < timeToMedicinesForChildrenListgroup.Count; key++)
                    {
                        long idTimeOfDay = timeToMedicinesForChildrenListgroup[key].ToList()[0].idTimeOfDay;
                        TimeOfDay timeOfDay = _timeOfDay_DAL.GetByTimeId(idTimeOfDay);
                        TimeOfDay timeOfDayToEdit = _details.TimeOfDays.FirstOrDefault(t => t.timeCode == timeOfDay.timeCode);
                        timeOfDay.theTime = timeOfDayToEdit.theTime;
                        //for (int a = 1; a <= 4; a++)
                        //{
                        //   TimeOfDay timeOfDayToEdit = _details.TimeOfDays.FirstOrDefault(t => t.timeCode == a);
                        //    timeOfDay.theTime = timeOfDayToEdit.theTime;
                        //    timeOfDay.theTime = timeOfDayToEdit.theTime;
                        //}
                    }
                }
                 
            }
            catch (Exception e)
            {
                return false;
            }
            
            return true;
        }

        public Settings Get(long userCode)
        {
            Settings _details = new Settings();

            //find user
            //find guardian 
            //find time to user
            User user = _userDAL.GetByIdentity(userCode);
            _details.User = new User();
            _details.User = user;

            List<guardiansToUser> guardiansToUser = _gurdiansToUser_DAL.GetByUser(userCode);
            _details.Guardians = new List<Guardian>();
            for (int i = 0; i < guardiansToUser.Count; i++)
            {
                Guardian guardian = _guardiansDAL.Get(guardiansToUser[i].guardianId);
                _details.Guardians[i]=new Guardian();
                _details.Guardians[i] = guardian;
            }

            _details.TimeOfDays = new List<TimeOfDay>();
            MedicinesToChild medicinesToChild = _medicinesToChild_DAL.GetByUser(userCode).First();
            List<TimeToMedicinesForChild> timeToMedicinesForChildList = _timeToMedicinesForChild_DAL.GetByMedicineToChild(medicinesToChild.userId);
            var timeToMedicinesForChildrenListgroup = timeToMedicinesForChildList.GroupBy(t => t.idTimeOfDay).Select(t => t.ToList()).ToList();
            for (int i = 0; i < timeToMedicinesForChildrenListgroup.Count; i++)//loop 4 times
            {
                long idTimeOfDay = timeToMedicinesForChildrenListgroup[i].ToList()[0].idTimeOfDay;
                TimeOfDay timeOfDay = _timeOfDay_DAL.GetByTimeId(idTimeOfDay);
                _details.TimeOfDays.Add(timeOfDay);
            }

            return _details;
        }
    }
}
