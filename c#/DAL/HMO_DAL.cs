using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HMO_DAL
    {
        MediDBEntities _DB = new MediDBEntities();

        public HMO Get()
        {
            var res = _DB.HMOes.ToList().FirstOrDefault();
            res = res == null ? new HMO() : res;
            return res;
        }

        public void Add(HMO details)
        {
            _DB.HMOes.Add(details);
            _DB.SaveChanges();
        }

        public void Edit(HMO details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
        public void Delete()
        {
           // _DB.Guardians.First().DeleteRow = false;
        }
    }
}
