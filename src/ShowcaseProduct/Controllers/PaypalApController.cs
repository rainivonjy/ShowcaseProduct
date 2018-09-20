using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowcaseProduct.Models;
using ShowcaseProduct.Models.ConstApplication;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    public class PaypalApController : Controller
    {
        
        private IPaypalPayement paypalPayement;
        public PaypalApController(IPaypalPayement paypalPayement)
        {
            this.paypalPayement = paypalPayement;
        }
        // GET: /<controller>/
        public IActionResult CreatePayment(List<BasketPaypal> orders)
        {
           var payment = paypalPayement.CreatePayment(orders, AllConstants.UrlReturnPaypal, AllConstants.UrlCancelPaypal, "sale");
            return new JsonResult(payment);
        }
        public IActionResult ReturnPaid(string paymentId, string token, string PayerID)
        {
            var payment = paypalPayement.ExecutePayment(paymentId, PayerID);

            // Hint: You can save the transaction details to your database using payment/buyer info

            return Ok();
        }
        public IActionResult CancelPaid()
        {
            return View();
        }
    }
}
