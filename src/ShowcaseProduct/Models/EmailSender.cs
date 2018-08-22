using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
namespace ShowcaseProduct.Models
{
    public class EmailSender : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Joe Bloggs", "jbloggs@example.com"));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.LocalDomain = "ntsoanyaina@gmail.com";
                await client.ConnectAsync("smtp.relay.uri", 25, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
