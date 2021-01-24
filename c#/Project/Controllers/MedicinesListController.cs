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
    public class MedicinesListController : ApiController
    {
        [Route("api/MedicinesList/Get")]
        public List<GenerateMedicine> Get(CodeTimeToUser _details)
        {
             return ;
        }
        
        [Route("api/MedicinesList/Update")]
        public void Update(CodeTimeToUser _details)
        {
             // עדכון של כל התרופות שנלקחו
        }
    }
}
