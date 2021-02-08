using DAL.HMO_DB_DAL;
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
        KingOfDosageDAL _KingOfDosageInHMO_DAL = new KingOfDosageDAL();
        public KingOfDosage Get()
        {
            var res = _DB.KingOfDosages.ToList().FirstOrDefault();
            res = res == null ? new KingOfDosage() : res;
            return res;
        }

        //public void Add()
        //{
        //    List<KingOfDosage> KingOfDosage = _KingOfDosageInHMO_DAL.Get();
        //    foreach (var item in KingOfDosage)
        //    {
        //        _DB.KingOfDosages.Add(new KingOfDosage() { kindOfDosageId = item.kindOfDosageId, kindOfDosageName = item.kindOfDosageName });
        //    }
        //    _DB.SaveChanges();
        //}

        public void Edit(KingOfDosage details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
        public void Delete()
        {
           // _DB.Guardians.First().DeleteRow = false;
        }

        public KingOfDosage getByIdKindOfChild(long idKindOfDosage)
        {
            var res = _DB.KingOfDosages.FirstOrDefault(id => id.kindOfDosageId == idKindOfDosage);
            res = res == null ? null : res;
            return res;
        }
    }
}
