using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class KingOfDosageBL
    {
        KingOfDosageDAL kingOfDosageDAL = new KingOfDosageDAL();

        public KingOfDosage Get()
        {
            return kingOfDosageDAL.Get();
        }

        public void AddOrEdit(KingOfDosage details)
        {
            if (details.kindOfDosageId == 0)
            {
                kingOfDosageDAL.Add();
            }
            else
            {
                kingOfDosageDAL.Edit(details);
            }
        }

        public void Delete()
        {
            kingOfDosageDAL.Delete();
        }
    }
}
