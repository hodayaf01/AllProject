using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class Medicines_DAL
    {
        HMO_DBEntities _DB = new HMO_DBEntities();

        public Medicine Get()
        {
            var res = _DB.Medicines.ToList().FirstOrDefault();
            res = res == null ? new Medicine() : res;
            return res;
        }
    }
}
