using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Imap;
using ShowcaseProduct.Models.ConstApplication;

namespace ShowcaseProduct.Models
{
    public class EmailSender : IEmailService
    {
        /// <summary>
        /// For send mail
        /// </summary>
        /// <param name="username"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string username,string to, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Site admin", "ntsoanyaina@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(username, to));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = body };
            using (var client = new SmtpClient())
            {
                client.Connect(AllConstants.NameServer, AllConstants.NumberPort);
                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove(AllConstants.NameAuth2);
                // Note: only needed if the SMTP server requires authentication
               client.Authenticate(AllConstants.MailForAuthentificationServer,AllConstants.MailPasswordForAuthentificationServer ); 
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
