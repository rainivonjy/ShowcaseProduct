using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ShowcaseProduct.Models
{
    public interface IPaypalPayement
    {
        Payment ExecutePayment(string paymentId, string payerId);
        Payment CreatePayment(List<BasketPaypal> orders, string returnUrl, string cancelUrl, string intent);
    }
}
