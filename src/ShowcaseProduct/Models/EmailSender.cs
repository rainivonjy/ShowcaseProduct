using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class EmailSender : IEmailService
    {
        Task IEmailService.SendAsync(string to, string subject, string body)
        {
            // Plug in your email service here to send an email.
            var smtp = new System.Net.Mail.SmtpClient();
            var mail = new System.Net.Mail.MailMessage();

            mail.IsBodyHtml = true;
            mail.From = new System.Net.Mail.MailAddress("prova@hln.it", "Prova Mail");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            //smtp = new SmtpClient("ServerName");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ntsoanyaina@gmail.com", "vonjy007");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 1000;
            var t = Task.Run(() => smtp.SendAsync(mail, null));
            return t;
    
        }
    }
}
