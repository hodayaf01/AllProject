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

        public List<MedicinesToClient> Get(long userId)
        {
            //int codeClient=_
            //List<MedicinesToClient> res = _DB.MedicinesToClients.ToList().FindAll(m=>m.clientId.CompareTo(userId)).ToList();           
            List<MedicinesToClient> res = _DB.MedicinesToClients.ToList().FindAll(m=>m.clientId==(userId)).ToList();           
            return res;
        }
    }
}
