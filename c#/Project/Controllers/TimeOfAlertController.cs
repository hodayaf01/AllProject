using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Mvc;

namespace Project.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TimeOfAlertController : ApiController
    {
       
        TimeOfAlert_BL _timeOfAlert_BL = new TimeOfAlert_BL();

        
        [Route("api/TimeOfAlert/Add")]
        [HttpPost]
        public bool Add(TimeOfAlertForUser timeOfAlertForUser)
        {
            return _timeOfAlert_BL.Add(timeOfAlertForUser);//v
        }
    }
}