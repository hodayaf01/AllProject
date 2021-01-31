using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HMO_DB_DAL
{
    public class TimeToMedicinesForClient_DAL
    {

        HMO_DBEntities _DB = new HMO_DBEntities();

        public List<TimeToMedicinesForClient> GetTimeOfDaysByTimeMidicineToClient(long medicineToClientId)
        {
            List<TimeToMedicinesForClient>  timeToMedicines= _DB.TimeToMedicinesForClients.Where(t => t.idMedicineToClient == medicineToClientId).ToList();
            timeToMedicines = timeToMedicines == null ? new List<TimeToMedicinesForClient>() { } : timeToMedicines;
            return timeToMedicines;
        }               
    }
}
