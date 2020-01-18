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
        public long Edit(Setting _details)
        {
            MediDBEntities DB = new MediDBEntities();

            User_DAL _userDAL = new User_DAL();
            GuardiansDAL _guardiansDAL = new GuardiansDAL();
            GurdiansToUser_DAL _gurdiansToUser_DAL = new GurdiansToUser_DAL();
            MedicinesToChild_DAL _medicinesToChild_DAL = new MedicinesToChild_DAL();
            TimeToMedicinesForChild_DAL _timeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();
            TimeOfDay_DAL _timeOfDay_DAL = new TimeOfDay_DAL();

            try
            {
                User user = DB.Users.FirstOrDefault(u => u.userId.Equals(_details.User.userId));
                if (_details.User.userName != null) { user.userName = _details.User.userName; }
                if (_details.User.email != null) { user.email = _details.User.email; }
                if (_details.User.password != null) { user.password = _details.User.password; }

                guardiansToUser guardiansToUser = DB.guardiansToUsers.FirstOrDefault(g => g.userId.Equals(_details.User.userId));
            }
            catch (Exception E)
            {
                return 0;
            }
            
            return 1;
        }
    }
}
