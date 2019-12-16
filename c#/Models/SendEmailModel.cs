using System;
using System.Collections.Generic;
//using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SendEmailModel
    {
            //parameters for send gmail
            //public FileStream Pdf { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public string Email { get; set; }

            public SendEmailModel(string subject, string body, string email)
            {
                //Pdf = pdf;
                Subject = subject;
                Body = body;
                Email = email;
            }
            public SendEmailModel()
            {

            }
        }
}
