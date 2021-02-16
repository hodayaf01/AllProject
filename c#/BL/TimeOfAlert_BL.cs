using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TimeOfAlert_BL
    {
        User_DAL _user_DAL = new User_DAL();
        TimeOfDay_DAL _TimeOfDay_DAL = new TimeOfDay_DAL();
        MedicinesToChild_DAL _MedicinesToChild_DAL = new MedicinesToChild_DAL();
        List<long> listCodeTime = new List<long>();
        public bool Add(TimeOfAlertForUser timeOfAlertForUser)
        {
            if (_user_DAL.AddSnooze(timeOfAlertForUser.snooze))//V
            { 
                if(_TimeOfDay_DAL.AddListTimeOfAlert(timeOfAlertForUser.timeOfDay))//V
                {
                    //List<DetailsAlert>[] _DetailsOfAlert =_MedicinesToChild_DAL.AddListMedicinesToUser(timeOfAlertForUser);
                    if (_MedicinesToChild_DAL.AddListMedicinesToUser(timeOfAlertForUser))//V
                    {
                        Alert_BL.AddTimesToMatForNewUser(timeOfAlertForUser);//V
                        return true;
                    }return false;
                }return false;
            }
            return false;
        }
    }
}