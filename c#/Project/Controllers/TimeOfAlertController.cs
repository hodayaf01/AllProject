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
        
        // GET: TimeOfAlert
        //public ActionResult Index()
        //{
        //    return View();
        //}

        TimeOfAlert_BL _timeOfAlert_BL = new TimeOfAlert_BL();

        
        [Route("api/TimeOfAlert/Add")]
        [HttpPost]
        public bool Add(Snooze snoozeDetails, List<TimeOfDay> listTimeOfDay, string token)
        {
            return _timeOfAlert_BL.Add(snoozeDetails, listTimeOfDay, token);
        }
        //[HttpGet]
        //public bool Add()
        //{
        //    //return _timeOfAlert_BL.Add(snoozeDetails, listTimeOfDay, token);
        //    return true;
        //}
    }
}