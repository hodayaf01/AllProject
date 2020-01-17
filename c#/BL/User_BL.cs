using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class User_BL
    {
        User_DAL _User_DAL = new User_DAL();

        public User Get(string code)
        {
            return _User_DAL.Get(code);
        }

        public void AddOrEdit(User details)
        {
            if (details.Id == 0)
            {
                _User_DAL.Add(details);
            }
            else
            {
                _User_DAL.Edit(details);
            }
        }
    }
}
