using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GuardiansDAL
    {
        MediDBEntities _DB = new MediDBEntities();

        public Guardian Get(long id)
        {
            var res = _DB.Guardians.FirstOrDefault(g=>g.Id==id);
            res = res == null ? new Guardian() : res;
            return res;
        }

        public long Add(Guardian details)
        {
            _DB.Guardians.Add(details);
            _DB.SaveChanges();
            return details.Id;
        }

        public void Edit(Guardian details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
        //public void Delete()
        //{
        //    _DB.Guardians.First().DeleteRow = false;
        //}
    }
}
