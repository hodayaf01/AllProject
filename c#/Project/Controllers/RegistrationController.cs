using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RegistrationController : ApiController
    {
        Registration_BL _registration_BL = new Registration_BL();

        [Route("api/Registration/Add")]
        [HttpPost]
        //רישום משתמש חדש, ואחזור 
        public PasswordToUser Add(Registration registration)
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
        //    User u = new User() { userName = "הודיה", password = "1234", email = "hodaya.farkash@gmail.com" };
        //    bool mailSend = Models.SendMail.SendEMail(new MessageGmail()
        //    {
        //        sendTo = u.email,
        //        Subject = "הרשמה לאפליקציית Medi",
        //        Body = string.Format("היי {0} \n הסיסמא שלך לאפליקציה: {1}", u.userName, u.password)
        //    });
        //    return mailSend;
        //}
    }
}
