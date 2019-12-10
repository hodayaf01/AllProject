﻿using DAL;
using DAL.HMO_DB_DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Registration_BL
    {
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
                long code= _userDAL.Add(_details.NewUser);
                //guardiansToUsers
                for (int i = 0; i < _details.Guardian.Count; i++)
                {
                    _guardiansDAL.Add(_details.Guardian[i]);
                    _guardiansToUserDAL.Add(new guardiansToUser() { userId = _details.NewUser.Id, guardianId = _details.Guardian[i].Id });
                }

                //Medicines To child
                //List<MedicinesToClient> medicinesList = _medicinesToClient_DAL.Get(_details.NewUser.Id);
                //for (int i = 0; i < medicinesList.Count; i++)
                //{
                //    _medicinesToChild_DAL.Add(new MedicinesToChild() { medicineId=medicinesList[i].medicineId,
                //    childId= medicinesList[i].clientId,
                //    Dosage= medicinesList[i].Dosage,
                //    kindOfDosage= medicinesList[i].kindOfDosage});
                //}
                //time of day?--------------
                return code;
            }
            // else
            return 404;
        }


    }
}
