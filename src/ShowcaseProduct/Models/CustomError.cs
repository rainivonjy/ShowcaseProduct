using ShowcaseProduct.Models.ConstApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class CustomError
    {
        public Status status { get; set; }
        public string message { get; set; }
        public CustomError()
        {
        }
        public CustomError(Status status)
        {
            this.status = status;
        }
        public CustomError(Status status, string message)
        {
            this.message = message;
        }
    }
}
