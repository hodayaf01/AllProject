using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.Clients;
using System.Configuration;

namespace Models
{
    public class SendSMS
    {

        public static bool sendmessage()
        {

            const string accountSid = "AC1817e44c5ba50186279750ed18602304";
            const string authToken = "ac3e6770611ddd853d9666a046c05961";
        
        
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "היי שירה, זו עוד הודעה שיגרתית שנשלחה בצורה לא שיגרתית :)",
                from: new Twilio.Types.PhoneNumber("+972525898637"),
                 to: new Twilio.Types.PhoneNumber("+972538320860")
            );
            Console.WriteLine(message.Sid);

            return true;
        }

    }
}
