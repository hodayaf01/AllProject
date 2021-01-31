using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class MedicinesToClient_DAL
    {
        HMO_DBEntities _DB = new HMO_DBEntities();
        User_DAL _User_DAL = new User_DAL();

        public List<MedicinesToClient> Get(string userToken)
        {//שולף את הת.ז של הילד לפי התוקן וכך שולף את כל התרופות מקליינט
            string childId= _User_DAL.GetChildIdByToken(userToken);         
            List<MedicinesToClient> res = _DB.MedicinesToClients.ToList().FindAll(m=>m.Client.clientId.Equals(childId)).ToList();  
            return res;
        }

    }
}
