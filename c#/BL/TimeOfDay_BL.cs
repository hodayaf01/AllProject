using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TimeOfDay_BL
    {
         TimeOfDay_DAL _TimeOfDay_DAL = new TimeOfDay_DAL();

        public TimeOfDay Get()
        {
            return _TimeOfDay_DAL.Get();
        }

        public void AddOrEdit(TimeOfDay details)
        {
            if (details.timeId == 0)
            {
                _TimeOfDay_DAL.Add(details);
            }
            else
            {
                _TimeOfDay_DAL.Edit(details);
            }
        }

        //public void Delete()
        //{
        //    _TimeOfDay_DAL.Delete();
        //} 
    }
}
