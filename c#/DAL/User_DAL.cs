using Models;
using Models.HMO_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User_DAL
    {
        MediDBEntities _DB = new MediDBEntities();
        HMO_DBEntities _HMO_DB = new HMO_DBEntities();

        public User GetById(string id)
        {
            User res = _DB.Users.ToList().FirstOrDefault(u => u.childId.Equals(id));
            res = res == null ? new User() : res;
            return res;
        }
        public User GetByIdentity(long userId)
        {
            User res = _DB.Users.FirstOrDefault(u => u.Id == userId);
            res = res == null ? new User() : res;
            return res;
        }

        public bool AddSnooze(Snooze snoozeDetails)
        {
            User res = _DB.Users.FirstOrDefault(u => u.Id ==snoozeDetails.userId);
            if (res == null) return false;
            res.snoozeCounter = snoozeDetails.snoozeCounter;
            res.snoozePeriod = snoozeDetails.snoozePeriod;
            _DB.SaveChanges();
            return true;
        }

        internal string GetChildIdByUserId(long userId)
        {
            User res = _DB.Users.FirstOrDefault(u => u.Id==userId);
            if (res == null) return "404";
            return res.childId;
        }

        public long Add(User _details)
        {

            //User newUser = new User()
            //{
            //    childId = _details.childId,
            //    userName = _details.userName,
            //    userHMO = _details.userHMO,
            //    email = _details.email,
            //    password = _details.password,
            //    points=0,
            //    token=_details.token,                
            //};
            //_DB.Users.Add(newUser);
            //_DB.SaveChanges();
            //return newUser.Id;

            _details.points = 0;
            _DB.Users.Add(_details);
            _DB.SaveChanges();
            return _details.Id;
        }

        //public void Add(User _details)//this fuc dont get User
        //{
        //    Client client = _HMO_DB.Clients.ToList().FirstOrDefault(
        //    c=>c.clientId.Equals(_details.userId)&&c.clientHMO==_details.userHMO);
        //    if (client != null)
        //    {
        //        
        //        //guardiansToUsers
        //        for()
        //    }
        //}

        public string GetChildIdByToken(string userToken)
        {
            User res = _DB.Users.FirstOrDefault(u => u.token.Equals(userToken));
            if (res == null) return "404";
            return res.childId;
        }
        public void Edit(User details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }

        public bool CheckPassword(PasswordToUser password)
        {
            return _DB.Users.First(u => u.Id == password.UserId).password == password.Password;
        }
    }
}
