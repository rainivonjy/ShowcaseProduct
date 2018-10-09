using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayPal.Api;
using ShowcaseProduct.Models.ConstApplication;

namespace ShowcaseProduct.Models
{
    public class PaypalPayement : IPaypalPayement
    {
        // Authenticate with PayPal
        //public readonly Dictionary<string, string> config;
        //public readonly string accessToken;
        public readonly APIContext apiContext;
        public PaypalPayement()
        {
            //config = ConfigManager.Instance.GetProperties();
            //accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(new OAuthTokenCredential(AllConstants.PayPalClientId, AllConstants.PayPalClientSecret).GetAccessToken());
            //apiContext = new APIContext(accessToken);
        }
        public Payment CreatePayment(List<BasketPaypal> orders, string returnUrl, string cancelUrl, string intent)
        {
             var payment = new Payment()
            {
                intent = intent,
                payer = new Payer() { payment_method = "paypal" },
                transactions = GetTransactionsList(orders),
                redirect_urls = new RedirectUrls()
                {
                    cancel_url = cancelUrl,
                    return_url = returnUrl
                }
            };
            var createdPayment = payment.Create(apiContext);
            return createdPayment;
        }
        public Payment ExecutePayment(string paymentId, string payerId)
        {
            var apiContext = new APIContext(new OAuthTokenCredential(AllConstants.PayPalClientId, AllConstants.PayPalClientSecret).GetAccessToken());

            var paymentExecution = new PaymentExecution() { payer_id = payerId };

            var executedPayment = new Payment() { id = paymentId }.Execute(apiContext, paymentExecution);

            return executedPayment;
        }
        private List<Transaction> GetTransactionsList(List<BasketPaypal> orders)
        {
            var transactionList = new List<Transaction>();
            foreach (BasketPaypal basketPaypal in orders)
            {
                transactionList.Add(new Transaction()
                {
                    description = "Transaction description.",
                    invoice_number = GetRandomInvoiceNumber(),
                    amount = CreateAmountPaypal(basketPaypal.Amount),
                    item_list = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        CreateItemPaypal(basketPaypal.Amount, basketPaypal.Quantity)
                    }
                    },
                });
            }
            

            return transactionList;
        }
        private string GetRandomInvoiceNumber()
        {
            return new Random().Next(999999999).ToString();
        }
        public Amount CreateAmountPaypal(decimal amount)
        {
            return new Amount()
            {
                currency = AllConstants.Currency,
                total = amount.ToString(),
                details = new Details()
                {
                    tax = "0",
                    shipping = "0",
                    subtotal = amount.ToString()
                }
            };
        }
        public Item CreateItemPaypal(decimal amount,int nbr)
        {
            return new Item()
            {
                name = AllConstants.NameItemTransactionPaypal,
                currency = AllConstants.Currency,
                price = amount.ToString(),
                quantity = nbr.ToString(),
                sku = AllConstants.sku
            };
        }
    }
}
