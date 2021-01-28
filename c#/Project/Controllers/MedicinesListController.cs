using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;

namespace Project.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MedicinesListController : ApiController
    {
        MedicinesList_BL _medicinesListBL = new MedicinesList_BL();
        
        [Route("api/MedicinesList/Get")]
        [HttpPost]
        //שליחת רשימת תרופות לפי קוד משתמש וזמן ביום
        public List<GenerateMedicine> Get(CodeTimeToUser _details)
        {
             return _medicinesListBL.Get(_details);
        }
        
        [Route("api/MedicinesList/Update")]
        [HttpPost]
        //עדכון כל התרופות שנלקחו
        public void Update(CodeTimeToUser _details)
        {
            MedicinesToUserBL.Update(_details);
        }
    }
}
