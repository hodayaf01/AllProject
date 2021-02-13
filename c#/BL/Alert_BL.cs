using DAL;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Alert_BL
    {
        static System.Timers.Timer t;      
        public static List<DetailsAlert>[,] _userDetailsOfAlert = new List<DetailsAlert>[24, 60];
        public static TimeOfDay_DAL _timeOfDay_DAL = new TimeOfDay_DAL();
        public static GuardiansDAL _GuardiansDAL = new GuardiansDAL();
        public static MedicinesToChild_DAL _MedicinesToChild_DAL = new MedicinesToChild_DAL();
        SMSCOMMS SMSEngine;


        //Creating a class while running the project
        static Alert_BL()
        {
            Beginning();
        }


        /*The func fills the matrix with content and start the clock running.
         Called every day at midnight.*/
        public static void Beginning()
        {
            //if (_MedicinesToChild_DAL.UpdateMedicincesToUsersEveryDay())
            bool isSucceeded = _MedicinesToChild_DAL.UpdateMedicincesToUsersEveryDay();
            CreatMatForChildMedicines();

            //play this fucn every day- fill mat details
            FillUserDetailsMat();

            t = new System.Timers.Timer();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(SendAlertEveryMinute);
            t.Interval = GetInterval();
            t.Start();
        }

        /*Create a matrix that describes all the hours and minutes of the day. It contains the users' token,
        by the time they need to take medication*/
        public static void CreatMatForChildMedicines()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    _userDetailsOfAlert[i, j] = new List<DetailsAlert>();
                }
            }
        }

        /*The clock is ticking*/
        static double GetInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }
        /*The function is called every minute. It sends to all children who need to take medicines, alert .*/
        static void SendAlertEveryMinute(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            if (!(now.Hour == 0 && now.Minute == 0))
            {
                t.Interval = GetInterval();
                t.Start();


                foreach (var childrenAlert in _userDetailsOfAlert[now.Hour, now.Minute])
                {
                    if (childrenAlert.snooze.snoozeCounter > childrenAlert.AlertCount)
                    {

                        //send alert to send by firabase
                        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        //serverKey - Key from Firebase cloud messaging server  
                        //tRequest.Headers.Add(string.Format("Authorization: key={0}", "key=AAAAat--WUo:APA91bHssfs8jZ9WQvhNjr-zp5KcoefJu6HgbA4cud2TIGcH_o6omHgn6TC_wE_JXnqakpbKfSfuAd_B5uVTtGWItGoSRsn7J5RCTxO6rzJdARoXup0vbhxjW60vgacvi5DL-t6k2hwg"));
                        tRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AAAAat--WUo:APA91bHssfs8jZ9WQvhNjr-zp5KcoefJu6HgbA4cud2TIGcH_o6omHgn6TC_wE_JXnqakpbKfSfuAd_B5uVTtGWItGoSRsn7J5RCTxO6rzJdARoXup0vbhxjW60vgacvi5DL-t6k2hwg");
                        ////Sender Id - From firebase project setting  
                        //tRequest.Headers.Add(string.Format("Sender: id={0}", "XXXXX.."));
                        tRequest.ContentType = "application/json";
                        var payload = new
                        {
                            //to = "eL1D6oH3L8U:APA91bF5oV8g-4JisK84aw6XmatgJ_5ArOidF6hCXjASj0mI6xlCjgvfZK4zb1wXktdHDAh5HdjP-RhUoldXBZua2059-e4IJEoOx2DPSjDtVZaKnfWOVxNHk_rAWo9j7DAeHlR4QQHZ",
                            to = "eihgr9lcIow:APA91bFjK4PjT-5zDS088pMGjT7E0XFsi5kRPkDw1l4DjHKbOv-XAQaCbbmU_uc5BTq-GB5GxPsMPSwLqrQB8uX70G_ti9Ru4kKij4_9FOcTUNTD3itlPpqxqeD7Lllu5TPCz8JkNOWU",
                            //to = childrenAlert.UserToken,
                            //priority = "high",
                            content_available = true,
                            notification = new
                            {
                                body = "הגיע הזמן לקחת תרופה",
                                title = "שלום לך!",
                                badge = 1,
                                click_action = "http://localhost:4200/Alert/30010/" + childrenAlert.CodeTime,//לשלוח קוד ילד
                                icon = "C:/Users/User/Desktop/AllProject/example/src/assets/images/LOGO.PNG"
                            },
                            data = new
                            {
                                key1 = now.Hour.ToString(),
                                key2 = now.Minute.ToString()
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

                        childrenAlert.AlertCount++;
                        PlaySnooze(childrenAlert.snooze.userId, DateTime.Now);
                    }
                    else if(childrenAlert.snooze.snoozeCounter == childrenAlert.AlertCount)
                        SendSMSToGuardians(childrenAlert);
                }
            }
            else
            {

                t.Stop();
                Beginning();
            }
        }

        public static void FillUserDetailsMat()
        {
            List<TimeOfDay> allTimes = _timeOfDay_DAL.GetAll();

            var allHours = allTimes.GroupBy(t => new { t.theTime.Hours, t.theTime.Minutes });
            //fill userDetailsAlert matrix in detailes
            foreach (var hour in allHours)
            {
                //_userToken[hour.Key.Hours, hour.Key.Minutes] = hour.ToList().Select(t => t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.token).ToList();
                if (hour.ToList().Find(t => t.TimeToMedicinesForChilds.Count > 0) != null)
                {
                    _userDetailsOfAlert[hour.Key.Hours, hour.Key.Minutes] = hour.ToList().Select(t => new DetailsAlert
                    {
                        UserToken = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.token,
                        AlertCount = 0,
                        UserName = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.userName,
                        snooze = new Snooze
                        {
                            userId = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.userId,
                            snoozePeriod = (int)t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.snoozePeriod,
                            snoozeCounter = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.snoozeCounter.Value,
                        },
                        CodeTime = t.timeCode
                    }).ToList();
                }
            }

            //foreach (var hour in allHours)
            ////t is imstance of TimeOfDay which contain all detaild about the child by kishrey gomlin
            //{
            //    timeOfChildrenMat[hour.Key.Hours, hour.Key.Minutes] = hour.ToList().Select(t => new ChildMedicin {
            //        userName = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.userName,
            //        Dosage = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.Dosage,
            //        kindOfDosageName = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.KingOfDosage.kindOfDosageName,
            //        userId = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.User.Id,
            //        medicineToChildId = t.TimeToMedicinesForChilds.FirstOrDefault().idMedicineToChild,
            //        medicineName = t.TimeToMedicinesForChilds.FirstOrDefault().MedicinesToChild.Medicine.midicineName
            //    }).ToList();
            //}
        }

        //פונקצי לשליחת הודעה דרך אסאמס4יו
        static async Task SendUsingAPIAsync(string guardianPhone, string childName)
        {
            Console.WriteLine("send massage to guardian");
            //HttpClient client = new HttpClient();
            ////Define the Required Variables
            //string key = "YnPDiagST";
            //string user = "0587828027";
            //string pass = "65576266";
            //string sender = "Medi";
            ////string recipient = "0538320860";
            ////string recipient = _registrationTest.Guardians[0].PhoneNumber;
            //string recipient = guardianPhone;
            //string msg = "Your Child- " + childName + " has not yet taken his medication";
            //var values = new Dictionary<string, string>
            //{
            //    { "key", key }, { "user", user },{ "pass", pass },
            //    { "sender", sender }, { "recipient", recipient },
            //    { "msg", msg }
            //};
            //var content = new FormUrlEncodedContent(values); //Encode the Data
            //var response = await client.PostAsync("https://www.sms4free.co.il/ApiSMS/SendSMS", content);
            //var responseString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseString); //Gives You How many Recipients the message was sent to
        }

        //הפעלת נודניק על ידי הילד. 
        //שליחה של זמן ההתראה ע"י הפיירבייס

        public static void SendSMSToGuardians(DetailsAlert childrenAlert)
        {
            //הילד חרג בהפעלת הנודניק- שליחת הודעה להורים
            List<Guardian> _guardiansDetails = _GuardiansDAL.GetGuardiansByUserId(childrenAlert.snooze.userId);
            foreach (var guardians in _guardiansDetails)
            {
                Console.WriteLine(guardians.guardianName + " " + guardians.PhoneNumber + " child name " + childrenAlert.UserName);
                SendUsingAPIAsync(guardians.PhoneNumber, childrenAlert.UserName); //This Method Sends Using API and its ASYNC (You have to wait until the process ends)
                Thread.Sleep(5000); //Sleep for 5 SECOND Until API FINISH His Work
            }
            //return true;
        }


        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //public static void PlaySnooze(CodeTimeToUser _codeTimeToUser, long timeId)
        public static void PlaySnooze(long userId, DateTime time)
        //מקבל קוד ילד וזמן שההתראה התבצעה
        {
            int hour = time.Hour, minute = time.Minute;
            if ((hour >= 0 && hour <= 23) && (minute >= 0 && minute <= 59))
            {
                DetailsAlert smoozeUserDidNotTakeMedicines = _userDetailsOfAlert[hour, minute].Find(u => u.snooze.userId == userId);
                if (smoozeUserDidNotTakeMedicines.snooze.snoozeCounter >= smoozeUserDidNotTakeMedicines.AlertCount)
                {
                    if (minute + smoozeUserDidNotTakeMedicines.snooze.snoozePeriod < 60)
                    {
                        _userDetailsOfAlert[hour, minute + smoozeUserDidNotTakeMedicines.snooze.snoozePeriod].Add(smoozeUserDidNotTakeMedicines);
                    }
                    else
                    {
                        if (hour + 1 < 24)
                            _userDetailsOfAlert[hour + 1, (minute + smoozeUserDidNotTakeMedicines.snooze.snoozePeriod) - 60].Add(smoozeUserDidNotTakeMedicines);
                        //else?
                    }
                }

            }
        }

        public int RemoveSnooze(CodeTimeToUser codeTimeToUser)
        {
            //למחוק מהמטריצה את הנודניק
            DateTime now = DateTime.Now;
            int hour = now.Hour;
            codeTimeToUser.UserID = 30010;
            codeTimeToUser.TimeOfDay = 1;
            bool continueLoop = true;
            int countSnooze=0;
            for (int j = now.Minute + 1; j < now.Minute + 15 && continueLoop; j++)
            {
                if (j <= 59)
                {
                    DetailsAlert snoozeToRemove = _userDetailsOfAlert[hour, j].FirstOrDefault(a => a.snooze.userId == codeTimeToUser.UserID && a.CodeTime == codeTimeToUser.TimeOfDay);
                    if (snoozeToRemove != null)
                    {
                        countSnooze = snoozeToRemove.AlertCount;
                        _userDetailsOfAlert[hour, j].Remove(snoozeToRemove);
                        continueLoop = false;
                    }
                    //snoozeToRemove = _userDetailsOfAlert[hour, j].RemoveAll(a => a.snooze.userId == codeTimeToUser.UserID && a.CodeTime == codeTimeToUser.TimeOfDay);
                }
                else
                {
                    DetailsAlert snoozeToRemove = _userDetailsOfAlert[hour + 1, j - 60].FirstOrDefault(a => a.snooze.userId == codeTimeToUser.UserID && a.CodeTime == codeTimeToUser.TimeOfDay);
                    if (snoozeToRemove != null)
                    {
                        countSnooze = snoozeToRemove.AlertCount;
                        _userDetailsOfAlert[hour + 1, j - 60].Remove(snoozeToRemove);
                        continueLoop = false;
                    }
                    //snoozeToRemove = _userDetailsOfAlert[hour+1, j - 60].RemoveAll(a => a.snooze.userId == codeTimeToUser.UserID && a.CodeTime == codeTimeToUser.TimeOfDay);
                }
            }
            return countSnooze;
        }
    }
}

