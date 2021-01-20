using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alert_BL
    {
        static System.Timers.Timer t;
        public static List<ChildMedicin>[,] timeOfChildrenMat = new List<ChildMedicin>[24, 60];
        static Alert_BL()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    timeOfChildrenMat[i, j] = new List<ChildMedicin>();
                }
            }

            Beginning();
            
        }

        

        public static void Beginning()
        {
            //play this fucn every day- fill mat details
            SetTimes();
            t = new System.Timers.Timer();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Interval = GetInterval();
            t.Start();
            // Console.ReadLine();
        }
        public static void Stop()
        {
            t.Stop();
        }

        static double GetInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Console.WriteLine(DateTime.Now.ToString("o"));

            //sent alert every minute 
            DateTime now = DateTime.Now;
            //if (!(now.Hour == 0 && DateTime.Now.TimeOfDay.Minutes == 0))
            if (!(now.Hour == 0 && now.Minute == 0))
            {
                t.Interval = GetInterval();
                t.Start();
                //  List<ChildMedicin> listChildMedicins= timeOfChildrenMat[DateTime.Now.TimeOfDay.Hours][DateTime.Now.Minute]
                List<ChildMedicin> listChildMedicinsNow =  timeOfChildrenMat[now.Hour,now.Minute].OrderBy(o => o.userId).ToList();
                // List<ChildMedicin> SortedList = listChildMedicinsNow.OrderBy(o => o.userId).ToList();//??
                // listChildMedicinsNow.Sort((x, y) => x.c .CompareTo(y.OrderDate));

                //List<ChildMedicin> medicinsForOneChild = new List<ChildMedicin>();
                // long childId = listChildMedicinsNow.First

                foreach (var childrenAlert in listChildMedicinsNow)
                {
                    //find or where??
                    List<ChildMedicin> childMedicins = listChildMedicinsNow.FindAll(m => m.userId.Equals(childrenAlert.userId)).ToList();
                    listChildMedicinsNow.RemoveAll(m => m.userId.Equals(childrenAlert.userId));
                    Console.WriteLine(childMedicins);
                }
            }
            else 
            {
                t.Stop();
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
               // Alert_BL = new Alert_BL();
            }
        }

        public static void SetTimes()
        {
            TimeOfDay_DAL _timeOfDay_DAL = new TimeOfDay_DAL();//????
            List<TimeOfDay> allTimes = _timeOfDay_DAL.GetAll();
            //List<TimeOfDay> allTimes = new List<TimeOfDay>();//get all times of day.

            //foreach (var time in allTimes)
            //{
            //    time = new TimeOfDay() { };
            //}

            var allHours = allTimes.GroupBy(t => new { t.theTime.Hours, t.theTime.Minutes });
            foreach (var hour in allHours)
                //t is imstance of TimeOfDay which contain all detaild about the child by kishrey gomlin
            {
                timeOfChildrenMat[hour.Key.Hours, hour.Key.Minutes] = hour.ToList().Select(t => new ChildMedicin {
                    userName = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.userName,
                    Dosage = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.Dosage,
                    kindOfDosageName = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.KingOfDosage.kindOfDosageName,
                    userId=t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.Id
                }).ToList();
            }
        }
    }
}
