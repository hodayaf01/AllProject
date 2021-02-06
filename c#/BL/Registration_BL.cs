using DAL;
using DAL.HMO_DB_DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Registration_BL
    {        
        Client_DAL _Client_DAL = new Client_DAL();
        User_DAL _userDAL = new User_DAL();
        GuardiansDAL _guardiansDAL = new GuardiansDAL();
        GurdiansToUser_DAL _guardiansToUserDAL = new GurdiansToUser_DAL();

        public long Add(Registration _details)
        {           
            //בדיקה שהמשתמש נמצא במאגר החולים
            //if(_Client_DAL.IsFound(_details))
           // {
                long codeUser= _userDAL.Add(_details.NewUser);
                
                for (int i = 0; i < _details.Guardians.Count; i++)
                {
                    long codeGuardian= _guardiansDAL.Add(_details.Guardians[i]);
                    _guardiansToUserDAL.Add(new guardiansToUser() { userId = codeUser, guardianId = codeGuardian });
                }


                //שליחת מייל               
                bool mailSend= Models.SendMail.SendEMail(new MessageGmail() {
                    sendTo=_details.NewUser.email,
                    Subject = "הרשמה לאפליקציית Medi",
                    Body = string.Format("היי {0} \n הסיסמא שלך לאפליקציה: {1}",_details.NewUser.userName,_details.NewUser.password)
                    });


           // }
            return _details.NewUser.Id;
            // else"
            return 404;
        }
       
    }
}
