using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using Models;

namespace Project.Controllers
{
    [EnableCors("*","*","*")]
    public class SettingsController : ApiController
    {
        
        Settings_BL _settings_BL = new Settings_BL();

        [Route("api/Settings/Edit")]
        public bool Edit(Settings _details)
        {
            return  _settings_BL.Edit(_details);
        }

        [Route("api/Settings/Get")]
        public Settings Get(int userCode)
        {
            return _settings_BL.Get(userCode);
        }
    }
}
