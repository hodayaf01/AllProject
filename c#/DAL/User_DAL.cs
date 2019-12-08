using Models;
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

        public User Get()
        {
            var res = _DB.Users.ToList().FirstOrDefault();
            res = res == null ? new User() : res;
            return res;
        }

        public long Add(User _details)
        {
            
            User newUser = new User()
            {
                userId = _details.userId,
                userName = _details.userName,
                userHMO = _details.userHMO,
                email = _details.email,
                password = _details.password
            };
            _DB.Users.Add(newUser);
            _DB.SaveChanges();
            return newUser.Id;
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

        public void Edit(User details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
