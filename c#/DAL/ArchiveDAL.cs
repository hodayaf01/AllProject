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

        public void Add(ArchiveTakeMedicine details)
        {
            _DB.ArchiveTakeMedicines.Add(details);
            _DB.SaveChanges();
        }
    }
}
