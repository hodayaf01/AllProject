using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class Client_DAL
    {
        HMO_DBEntities _DB = new HMO_DBEntities();


        public bool IsFound(Registration newUser)
        {
            var res = _DB.Clients.ToList().FirstOrDefault(c => c.clientId.Equals(newUser.NewUser.childId) && c.clientHMO.Equals(newUser.NewUser.userHMO));
            if (res == null) return false;
            string name = res.clientName;
            return true;
            //res = res == null ? new Client() : res;
            //return res;
        }
    }
}
