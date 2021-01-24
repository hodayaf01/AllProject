using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class TimeOfAlertController : Controller
    {
        // GET: TimeOfAlert
        public ActionResult Index()
        {
            return View();
        }

        TimeOfAlert_BL _timeOfAlert_BL = new TimeOfAlert_BL();

        [HttpPost]
        [Route("api/TimeOfAlert/Add")]
        public bool Add(Snooze _snoozeDetails, List<TimeOfDay> _details)
        { 
            return _timeOfAlert_BL.Add(_snoozeDetails,_details);
        }
    }
}