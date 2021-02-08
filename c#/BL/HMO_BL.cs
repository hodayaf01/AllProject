using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class HMO_BL
    {
        HMO_DAL _HMO_DAL = new HMO_DAL();

        public List< HMO> Get()
        {
            return _HMO_DAL.Get();
        }

        public void AddOrEdit(HMO details)
        {
            if (details.IdHMO == 0)
            {
                _HMO_DAL.Add(details);
            }
            else
            {
                _HMO_DAL.Edit(details);
            }
        }

        public void Delete()
        {
            _HMO_DAL.Delete();
        }
    }
}
