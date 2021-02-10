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
        Alert_BL _alert_BL = new Alert_BL();
        [Route("api/Alert/V")]
        [HttpPost]
        public void AlertV(CodeTimeToUser codeTimeToUser)
        {
            _alert_BL.RemoveSnooze(codeTimeToUser);
        }
    }
}
