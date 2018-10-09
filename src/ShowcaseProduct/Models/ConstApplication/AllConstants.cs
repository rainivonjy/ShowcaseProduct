using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models.ConstApplication
{
    public static class AllConstants
    {
        // For configuration send mail
        public const string NameAuth2 = "XOAUTH2";

        public const string NameServer = "smtp.gmail.com";

        public const int NumberPort = 587;

        public const string MailForAuthentificationServer = "ntsoanyaina@gmail.com";

        public const string MailPasswordForAuthentificationServer = "vonjy007";

        // All image in application;
        public const string srcImage = "download";
        public const string PathFolderImage = "wwwroot/download";

        // Config for paypal
        public const string NameItemTransactionPaypal = "Payment";
        public const string Currency = "USD";
        public const string sku = "sku";
        public const string tax = "0";
        public const string shipping = "0";
        public const string PayPalClientId = "ntsoanyaina-facilitator@gmail.com";
        public const string PayPalClientSecret = "access_token$sandbox$kqxcbv7d6v96m4w5$651e41b45ee48a4c96ccc9153570310b";
        public const string UrlReturnPaypal = "http://localhost:64045/Paypal/ReturnPaid";
        public const string UrlCancelPaypal = "http://localhost:64045/Paypal/CancelPaid";
    }
}
