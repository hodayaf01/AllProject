using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    public class UsersController : ApiController
    {
        User_BL _user_BL = new User_BL();

        [HttpPost]
        [Route("api/User/Add")]
        public void Add(User user)
        {
            _user_BL.AddOrEdit(user);
        }
        public User Get()
        {
            return _user_BL.Get();
        }
        public void Edit(User user)
        {
            _user_BL.AddOrEdit(user);
        }
    }
}
