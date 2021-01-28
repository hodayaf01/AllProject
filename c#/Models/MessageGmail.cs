using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MessageGmail
    {
        public string sendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = false;
    }

    public static class SendMail
    {
        private static string senderName = "Medi";
        private static string senderEmailId = "Shiralulvi1@gmail.com";
        private static string password = "0548523727";
        private static MailAddress fromAddress = new MailAddress(senderEmailId, senderName);
        
        //מקבלת פרטי הודעת מייל
        public static bool SendEMail(MessageGmail message)
        {
            var success = false;
            var msg = createMessage(message);
            var client = createClient();
            try
            {
                client.Send(msg);
                success = true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

        //יצירת הודעת מייל
        private static MailMessage createMessage(MessageGmail message)
        {
            MailMessage msg = new MailMessage()
            {
                From = fromAddress,
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = message.IsBodyHtml,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8
            };

            //מצרף את כתובות המייל לשליחה
            msg.To.Add(message.sendTo);

            return msg;
        }
            //התממשקות לsmtp
        private static SmtpClient createClient()
        {
            
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(fromAddress.Address, password);
            return client;
        }
        
    }
}

