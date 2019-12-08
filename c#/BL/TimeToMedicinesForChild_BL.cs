using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TimeToMedicinesForChild_BL
    {
        TimeToMedicinesForChild_DAL _TimeToMedicinesForChild_DAL = new TimeToMedicinesForChild_DAL();

        public TimeToMedicinesForChild Get()
        {
            return _TimeToMedicinesForChild_DAL.Get();
        }

        public void AddOrEdit(TimeToMedicinesForChild details)
        {
            if (details.Id == 0)
            {
                _TimeToMedicinesForChild_DAL.Add(details);
            }
            else
            {
                _TimeToMedicinesForChild_DAL.Edit(details);
            }
        }
    }
}
