using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class MessageGmail
    {
        ////public Dictionary<string, string> ToList { get; set; } = new Dictionary<string, string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = false;
        //public List<Attachment> ListFileAttachment { get; set; } = new List<Attachment>();

    }
    //public static bool CreateMail(SendEmailModel model)
    //{

    //    //שליחת מייל
    //    MessageGmail mg = new MessageGmail();
    //    //mg.Body = model.Body;
    //    //mg.Subject = model.Subject;
    //    mg.Body = "הסיסמא שלך לאפליקציה היא: ";
    //    mg.Subject = "הרשמה לאפליקציית Medi";

    //    //model.Email="shiralulvi1@gmail.com";
    //    return SendMail.SendEMail(mg);
    //}
    public static class SendMail
    {
        private static string senderName = "Medi";
        private static string senderEmailId = "shiralulvi1@gmail.com";
        private static string password = "0548523727";
        private static MailAddress fromAddress = new MailAddress(senderEmailId, senderName);


        public static bool SendEMail(MessageGmail message)
        {
            var success = false;
            var msg = createMessage(message);
            //msg = addFilesToMessage(message, msg);

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
          
              
                msg.To.Add("shirelmegidish1@gmail.com");
            
            return msg;
        }

        private static SmtpClient createClient()
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(fromAddress.Address, password);
            return client;
        }

        ////private static MailMessage addFilesToMessage(MessageGmail originalMessage, MailMessage msg)
        ////{
        ////    if (originalMessage.ListFileAttachment != null)
        ////    {
        ////        foreach (var file in originalMessage.ListFileAttachment)
        ////        {
        ////            ContentType mimeType = new ContentType("text/html");
        ////            AlternateView alternate = AlternateView.CreateAlternateViewFromString(msg.Body, mimeType);
        ////            msg.Attachments.Add(file);
        ////            msg.AlternateViews.Add(alternate);
        ////        }
        ////    }
        ////    return msg;
        ////}
    }

}
