using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GurdiansToUser_DAL
    {
        MediDBEntities _DB = new MediDBEntities();

        public guardiansToUser Get()
        {
            var res = _DB.guardiansToUsers.ToList().FirstOrDefault();
            res = res == null ? new guardiansToUser() : res;
            return res;
        }

        public void Add(guardiansToUser guardiansToUser)
        {
            _DB.guardiansToUsers.Add(new guardiansToUser() {  userId = guardiansToUser.userId, guardianId=guardiansToUser.guardianId});            
            _DB.SaveChanges();
        }

        public void Edit(guardiansToUser details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
        //public void Delete()
        //{
        //    _DB.guardiansToUsers.First().DeleteRow = false;
        //}
    }
}
