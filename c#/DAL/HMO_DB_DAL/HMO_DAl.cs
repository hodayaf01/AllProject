using Models;
using Models.HMO_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class HMO_DAL
    {
        HMO_DBEntities _DB = new HMO_DBEntities();

        public List<Models.HMO_db.HMO> Get()
        {
            var res = _DB.HMOes.ToList();
            return res;
        }
    }
}
