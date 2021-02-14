using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArchiveDAL
    {
        MediDBEntities _DB = new MediDBEntities();
        public void Add(ArchiveTakeMedicine archiveTakeMedicine)
        {
            _DB.ArchiveTakeMedicines.Add(archiveTakeMedicine);
            _DB.SaveChanges();
        }

        public List<ArchiveTakeMedicine> Get(long userId)
        {
            var res = _DB.ArchiveTakeMedicines.Where(a => a.userId==userId).ToList();
            res = res == null ? new List<ArchiveTakeMedicine>() : res;
            return res;
        }

        public void Edit(ArchiveTakeMedicine details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }

        public List<ArchiveTakeMedicine> GetToDay(long userId)
        {

            var res = _DB.ArchiveTakeMedicines.Where(a => a.userId == userId && a.date.Equals(DateTime.Now.Date)).ToList();
            res = res == null ? new List<ArchiveTakeMedicine>() : res;
            return res;
        }
    }
}
