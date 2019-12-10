using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MedicinesToChild_BL
    {
        MedicinesToChild_DAL _MedicinesToChild_DAL = new MedicinesToChild_DAL();

        public MedicinesToChild Get()
        {
            return _MedicinesToChild_DAL.Get();
        }

        public bool Add(long userId, long codeTime)
        {                   
            return _MedicinesToChild_DAL.Add(userId, codeTime);                    
        }
    }
}
