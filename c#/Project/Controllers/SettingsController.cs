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
    [EnableCors("*", "*", "*")]
    public class SettingsController : ApiController
    {
        
        Settings_BL _settings_BL = new Settings_BL();

        [Route("api/Settings/Edit")]
        [HttpPost]
        public bool Edit(Settings _details)
        {
            //Settings _details= _settings_BL.Get(password);
            return  _settings_BL.Edit(_details);
        }

        [Route("api/Settings/Get")]
        [HttpPost]
        public Settings Get(PasswordToUser password)
        {
            //return new Settings();
            //Settings settings= _settings_BL.Get(password);
            Settings settings = new Settings();
            settings.Guardians = new List<Guardian>() { new Guardian() { Id = 0, guardianName = "nor" } };
            //settings.Guardians[0].guardianName  "משה";
            settings.User = new User() { Id = 30010, password = "123", userName = "HodayaF",childId= "207420274" };
            //settings.User.password = "1234";
            //settings.User.Id = 30010;
            //settings.User.userName = "hodaya";

            settings.Guardians.Add(new Guardian() { guardianName = "moran", PhoneNumber = "0548523727" });
            //settings.TimeOfDays[0].theTime= TimeSpan.
            _settings_BL.Edit(settings);
            //return null;
            return _settings_BL.Get(password);

        }
    }
}
