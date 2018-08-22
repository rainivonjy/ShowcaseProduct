using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    } 
}
