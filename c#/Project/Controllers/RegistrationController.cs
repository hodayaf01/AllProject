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
    public class RegistrationController : ApiController
    {
        Registration_BL _registration_BL = new Registration_BL();

        [HttpPost]
        [Route("api/Registration/Add")]
        public long Add(Registration registration)
        {
            return _registration_BL.Add(registration);
        }
        //public Registration Get()
        //{
        //    return _registration_BL.Get();
        //}
        public void Edit(Registration registration)
        {
            //_registration_BL.Edit(registration);
        }

        //[Route("api/SendEmail")]
        //[HttpGet]
        //public bool SendEmail()
        //{
        //    //SendEmailModel model = new SendEmailModel()
        //    //{
        //    //    Body =  "הסיסמא שלך לאפליקציה היא: ",
        //    //    Subject = "הרשמה לאפליקציית Medi",
        //    //};
        //    return _registration_BL.CreateMail();
        //}
    }
}
