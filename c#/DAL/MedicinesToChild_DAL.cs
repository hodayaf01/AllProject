using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicinesToChild_DAL
    {
        MediDBEntities _DB = new MediDBEntities();
        DAL.HMO_DB_DAL.MedicinesToClient_DAL _MedicinesToClient_DAL = new HMO_DB_DAL.MedicinesToClient_DAL();
        public MedicinesToChild Get()
        {
            var res = _DB.MedicinesToChilds.ToList().FirstOrDefault();
            res = res == null ? new MedicinesToChild() : res;
            return res;
        }

        public void Add(long userId)
        {
            List<MedicinesToClient> medicinesToClients = _MedicinesToClient_DAL.Get(userId);
            foreach (var item in medicinesToClients)
            {
                _DB.MedicinesToChilds.Add(new MedicinesToChild() { medicineId=item.medicineId,childId=userId,kindOfDosage=item.kindOfDosage,Dosage=item.Dosage});
            }
            _DB.SaveChanges();
        }

        public void Edit(MedicinesToChild details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
