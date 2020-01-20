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
    public class HomePageController : ApiController
    {
       //[Route("api/Home/Get")]
       /*public List<GenerateMedicine> Get(int timeOfDay)
       {
            return ;
       }*/
    }
}
