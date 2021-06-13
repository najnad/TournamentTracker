using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void SendEmail(string to, string subject, string body)
        {
            SendEmail(new List<string> { to }, new List<string>(), subject, body);
        }

        /// <summary>
        /// Sends email to players in the tournament.
        /// </summary>
        /// <param name="to">List<string></param>
        /// <param name="bcc">List<string></param>
        /// <param name="subject">string</param>
        /// <param name="body">string</param>
        public static void SendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderName"));

            MailMessage mail = new MailMessage();

            foreach (string email in to)
            {
                mail.To.Add(email); 
            }

            foreach (string email in bcc)
            {
                mail.Bcc.Add(email);
            }

            mail.From = fromAddress;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();

            client.Send(mail);
        }

    }
}
