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
    }
}
