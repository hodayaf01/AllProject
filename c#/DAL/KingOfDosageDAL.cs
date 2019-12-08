using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KingOfDosageDAL
    {
        MediDBEntities _DB = new MediDBEntities();

        public KingOfDosage Get()
        {
            var res = _DB.KingOfDosages.ToList().FirstOrDefault();
            res = res == null ? new KingOfDosage() : res;
            return res;
        }

        public void Add(KingOfDosage details)
        {
            _DB.KingOfDosages.Add(details);
            _DB.SaveChanges();
        }

        public void Edit(KingOfDosage details)
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
