using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class RequestShop
    {
        public int NbShow { get; set; }
        public int Pagination { get; set; }
        public int Total { get; set; }
        public bool IsDiscount { get; set; }
        public bool IsNewest { get; set; }
        public bool IsFirstRequest { get; set; }
        public int CurrentPagination { get; set; }
        public int CurrentTotal { get; set; }
    }
}
