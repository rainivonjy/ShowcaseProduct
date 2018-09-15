using System;
using System.Collections.Generic;

namespace ShowcaseProduct.Models
{
    public partial class Relationprix
    {
        public int Id { get; set; }
        public long IdProduit { get; set; }
        public long IdPrix { get; set; }

        public virtual Prix IdPrixNavigation { get; set; }
        public virtual Product IdPrix1 { get; set; }
    }
}
