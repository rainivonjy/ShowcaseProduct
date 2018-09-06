using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Imap;

namespace ShowcaseProduct.Models
{
    public class EmailSender : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Joe Bloggs", "ntsoanyaina@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("ntsoanyaina@gmail.com", "ntsoanyaina@gmail.com"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = body };

            var credentials = new NetworkCredential("ntsoanyaina@gmail.com", "vonjy007");

           /* var client = new SmtpClient(smtpEmail.smtp)
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = credentials
            };*/


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);


                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
               client.Authenticate("ntsoanyaina@gmail.com", "vonjy007");

                
                client.Send(emailMessage);
                client.Disconnect(true);
            }

        }
    }
}
