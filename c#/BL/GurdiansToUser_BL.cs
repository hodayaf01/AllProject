using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GurdiansToUser_BL
    {
        GurdiansToUser_DAL _GurdiansToUser_DAL = new GurdiansToUser_DAL();

        //public guardiansToUser Get()
        //{
        //    return _GurdiansToUser_DAL.Get();
        //}

        public void AddOrEdit(guardiansToUser details)
        {
            if (details.Id == 0)
            {
                _GurdiansToUser_DAL.Add(details);
            }
            else
            {
                _GurdiansToUser_DAL.Edit(details);
            }
        }

        //public void Delete()
        //{
        //    _GurdiansToUser_DAL.Delete();
        //}
    }
}
