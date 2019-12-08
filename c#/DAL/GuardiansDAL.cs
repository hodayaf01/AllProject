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

        public Guardian Get()
        {
            var res = _DB.Guardians.ToList().FirstOrDefault();
            res = res == null ? new Guardian() : res;
            return res;
        }

        public void Add(Guardian details)
        {
            _DB.Guardians.Add(details);
            _DB.SaveChanges();
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
