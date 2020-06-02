using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace TPA.Presentation.Helpers
{
    public class Email
    {

        SmtpClient smtp;

        public Email()
        {
            smtp = new SmtpClient();
        }

        public bool Send(string toEmail,string body,string subject)
        {
            try
            {
                MailMessage message = new MailMessage(((System.Net.NetworkCredential)smtp.Credentials).UserName, toEmail);
                message.Body = body;
                message.IsBodyHtml = true;
                message.Subject = subject;
                smtp.Send(message);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}