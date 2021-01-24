using DAL;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alert_BL
    {
        static System.Timers.Timer t;
        public static List<ChildMedicin>[,] timeOfChildrenMat = new List<ChildMedicin>[24, 60];
        public static List<string>[,] _userToken = new List<string>  [24, 60];
        static Alert_BL()
        {
            Beginning();            
        }

        public static void CreatMatForChildMedicin()
        { 
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    timeOfChildrenMat[i, j] = new List<ChildMedicin>();

                    _userToken[i, j] = new List<string>();
                }
            }
        }
        

        public static void Beginning()
        {
            CreatMatForChildMedicin();

            //play this fucn every day- fill mat details
            SetTimes();

            t = new System.Timers.Timer();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Interval = GetInterval();
            t.Start();
            // Console.ReadLine();
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

                    //-------------------------------
                    //send alert to send by firabase
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    //serverKey - Key from Firebase cloud messaging server  
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", "key=AAAAat--WUo:APA91bHssfs8jZ9WQvhNjr-zp5KcoefJu6HgbA4cud2TIGcH_o6omHgn6TC_wE_JXnqakpbKfSfuAd_B5uVTtGWItGoSRsn7J5RCTxO6rzJdARoXup0vbhxjW60vgacvi5DL-t6k2hwg"));
                    ////Sender Id - From firebase project setting  
                    //tRequest.Headers.Add(string.Format("Sender: id={0}", "XXXXX.."));
                    tRequest.ContentType = "application/json";
                    var payload = new
                    {
                        to = "eL1D6oH3L8U:APA91bF5oV8g-4JisK84aw6XmatgJ_5ArOidF6hCXjASj0mI6xlCjgvfZK4zb1wXktdHDAh5HdjP-RhUoldXBZua2059-e4IJEoOx2DPSjDtVZaKnfWOVxNHk_rAWo9j7DAeHlR4QQHZ",
                        //priority = "high",
                        content_available = true,
                        notification = new
                        {
                            body = "גיע הזמן לקחת תרופה",
                            title = "שלום לך!",
                            badge = 1
                        },
                        data = new
                        {
                            key1 = "value1",
                            key2 = "value2"
                        }

                    };

                    string postbody = JsonConvert.SerializeObject(payload).ToString();
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        String sResponseFromServer = tReader.ReadToEnd();
                                        //result.Response = sResponseFromServer;
                                    }
                            }
                        }
                    }
                }
            }
            else 
            {
                t.Stop();
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // Alert_BL = new Alert_BL();
                Beginning();
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
                    userId=t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.Id,
                  medicineToChildId=t.TimeToMedicinesForChilds.FirstOrDefault().idMedicineToChild,
                  medicineName=t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.Medicine.midicineName
                }).ToList();
            }



            //--------------------------------------------------------------
            //--------------------------------------------------------------
            //fill userToken matrix in detailes
        }
    }
}
