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
        public bool Add(Snooze _snoozeDetails,List<TimeOfDay> _listTimeOfDay,string token)
        {
            if (_user_DAL.AddSnooze(_snoozeDetails))
            { 
                if(_TimeOfDay_DAL.AddListTimeOfAlert(_listTimeOfDay))
                {
                    if (_MedicinesToChild_DAL.AddListMedicinesToUser(_snoozeDetails.userId, _listTimeOfDay, token))
                    {
                        return true;
                    } return false;
                }return false;
            }
            return false;
        }
    }
}