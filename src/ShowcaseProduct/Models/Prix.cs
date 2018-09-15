using System;
using System.Collections.Generic;

namespace ShowcaseProduct.Models
{
    public partial class Prix
    {
        public Prix()
        {
            Relationprix = new HashSet<Relationprix>();
        }

        public long Id { get; set; }
        public double PrixUniraire { get; set; }
        public double? PrixPromotionelle { get; set; }
        public DateTime? Datedebut { get; set; }
        public DateTime? DateFin { get; set; }

        public virtual ICollection<Relationprix> Relationprix { get; set; }
    }
}
