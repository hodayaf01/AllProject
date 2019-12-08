using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class KingOfDosageDAL
    {
        Models.HMO_DBEntities _DB = new HMO_DBEntities();

        public KingOfDosage Get()
        {
            var res = _DB.KingOfDosages.ToList().FirstOrDefault();
            res = res == null ? new KingOfDosage() : res;
            return res;
        }
    }
}
