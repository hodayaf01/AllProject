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
        MedicinesDAL _medicinesDAL = new MedicinesDAL();
        KingOfDosageDAL _KingOfDosageDAL = new KingOfDosageDAL();
        MedicinesToChild_DAL _MedicinesToChild_DAL = new MedicinesToChild_DAL();
        List<long> listCodeTime = new List<long>();
        public bool Add(Snooze _snoozeDetails,List<TimeOfDay> _details)
        {
            //הפעולה מקבלת את הקוד של המשתמש ורשימה של זמנים ביום         

            //צריך להיות במקום אחר, כי אנחנו רוצות שהוא התבצע פעם אחת- הוספת כל התרופות והמינונים        
            _medicinesDAL.Add();
            _KingOfDosageDAL.Add();
            //bool insertTime = false;//בדיקה שכל הזמנים עודכנו במסד נתונים
            //מתבצע כל פעם כי שולחים כל פעם זמן אחר
            foreach (var item in _details)
            {
                //?????
                if (!(_TimeOfDay_DAL.Add(item) || _MedicinesToChild_DAL.Add(userId, item.timeId)))
                    return false;
                //רשימה של הקודים למשתמש
                listCodeTime.Add(item.timeId);
            }
            return true;
        }
    }
}