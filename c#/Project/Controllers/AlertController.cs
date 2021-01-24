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
    public class AlertController : ApiController
    {
        Alert_BL _alert_BL = new Alert_BL();

        [Route("api/Alert")]
        //[HttpPost]
        //public long Add(Registration registration)
        //{
        //    return _registration_BL.Add(registration);
        //}
        //public Registration Get()
        //{
        //    return _registration_BL.Get();
        //}
        public void Edit(Alert alert)
        {
            //_registration_BL.Edit(registration);
        }

//public List<MedicinesToChild> Get()
        //public List<MedicinesToChild> Get(long userId)
        
        //{

        //}
    }
}
