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
    public class AlertController : ApiController
    {
        //Alert_BL _alert_BL = new Alert_BL();
        [Route("api/Alert/V")]
        [HttpPost]
        public int AlertV(CodeTimeToUser codeTimeToUser)
        {
            //מחזיר את כמות הנודניקים שהיו לילד כדי להעביר לקיחת רשימת תרופות
            //todo check static
            return  Alert_BL.RemoveSnooze(codeTimeToUser);
        }
    }
}
