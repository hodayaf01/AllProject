using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GuardianBL
    {
        GuardiansDAL _guardiansDAL = new GuardiansDAL();

        public Guardian Get(long id)
        {
            return _guardiansDAL.Get(id);
        }

        public void AddOrEdit(Guardian details)
        {
            if (details.Id == 0)
            {
                _guardiansDAL.Add(details);
            }
            else
            {
                _guardiansDAL.Edit(details);
            }
        }

        //public void Delete()
        //{
        //    _guardiansDAL.Delete();
        //}
    }
}
