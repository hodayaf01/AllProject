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
        //TimeToMedicinesForChild _TimeToMedicinesForChild = new TimeToMedicinesForChild();
        public MedicinesToChild Get()
        {
            var res = _DB.MedicinesToChilds.ToList().FirstOrDefault();
            res = res == null ? new MedicinesToChild() : res;
            return res;
        }

        public List<MedicinesToChild> GetByUser(long id)
        {
            var res = _DB.MedicinesToChilds.Where(m => m.childId == id).ToList();
            res = res == null ? null : res;
            return res;
        }

        public bool Add(long userId, long timeCode)
        {
            List<MedicinesToClient> medicinesToClients = _MedicinesToClient_DAL.Get(userId);
            foreach (var item in medicinesToClients)
            {
                MedicinesToChild medicinesToChild = new MedicinesToChild()
                {
                    medicineId = item.medicineId,
                    childId = userId,
                    kindOfDosage = item.kindOfDosage,
                    Dosage = item.Dosage
                };
                _DB.MedicinesToChilds.Add(medicinesToChild);
                _DB.TimeToMedicinesForChilds.Add(new TimeToMedicinesForChild() { idMedicineToChild = medicinesToChild.Id, idTimeOfDay = timeCode });
            }
            if (_DB.SaveChanges() == 0)
                return false;
            return true;
        }

        public void Edit(MedicinesToChild details)
        {
            _DB.Entry(details);
            _DB.SaveChanges();
        }
    }
}
