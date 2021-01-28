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
        string phoneNumber;
        string nameChild;
        Client_DAL _Client_DAL = new Client_DAL();
        User_DAL _userDAL = new User_DAL();
        GuardiansDAL _guardiansDAL = new GuardiansDAL();
        GurdiansToUser_DAL _guardiansToUserDAL = new GurdiansToUser_DAL();
        MedicinesToChild_DAL _medicinesToChild_DAL = new MedicinesToChild_DAL();
        MedicinesToClient_DAL _medicinesToClient_DAL = new DAL.HMO_DB_DAL.MedicinesToClient_DAL();
        public long Add(Registration _details)
        {           
            //func get in client!!!!!!!!
            //Client client = Clients.ToList().FirstOrDefault();
            if(_Client_DAL.IsFound(_details))
            {
                long codeUser= _userDAL.Add(_details.NewUser);
                //guardiansToUsers
                for (int i = 0; i < _details.Guardians.Count; i++)
                {
                    long codeGuardian= _guardiansDAL.Add(_details.Guardians[i]);
                    _guardiansToUserDAL.Add(new guardiansToUser() { userId = codeUser, guardianId = codeGuardian });
                }

                //Medicines To child
                //List<MedicinesToClient> medicinesList = _medicinesToClient_DAL.Get(_details.NewUser.childId);
                //for (int i = 0; i < medicinesList.Count; i++)
                //{
                //    _medicinesToChild_DAL.Add(new MedicinesToChild()
                //    {
                //       // medicineId = medicinesList[i].medicineId,
                //        userId = medicinesList[i].clientId,
                //        Dosage = medicinesList[i].Dosage,
                //        kindOfDosage = medicinesList[i].kindOfDosage
                //    });
                //}


                //שליחת מייל               
                bool mailSend= Models.SendMail.SendEMail(new MessageGmail() {
                    sendTo=_details.NewUser.email,
                    Subject = "הרשמה לאפליקציית Medi",
                    Body = string.Format("היי {0} \n הסיסמא שלך לאפליקציה: {1}",_details.NewUser.userName,_details.NewUser.password)
                    });


            }
            // else
            return 404;
        }
       
    }
}
