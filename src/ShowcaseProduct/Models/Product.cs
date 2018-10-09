using System;
using System.Collections.Generic;

namespace ShowcaseProduct.Models
{
    public partial class Product
    {
        public Product()
        {
            Commande = new HashSet<Commande>();
            Relationprix = new HashSet<Relationprix>();
        }

        public long Id { get; set; }
        public string Nom { get; set; }
        public string Image { get; set; }
        public string Marque { get; set; }

        public virtual ICollection<Commande> Commande { get; set; }
        public virtual ICollection<Relationprix> Relationprix { get; set; }
    }
}
