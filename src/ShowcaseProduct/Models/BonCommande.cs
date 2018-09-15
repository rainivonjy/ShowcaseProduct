using System;
using System.Collections.Generic;

namespace ShowcaseProduct.Models
{
    public partial class BonCommande
    {
        public BonCommande()
        {
            Commande = new HashSet<Commande>();
        }

        public long Id { get; set; }
        public string IdUser { get; set; }
        public bool Payer { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<Commande> Commande { get; set; }
        public virtual AspNetUsers IdUserNavigation { get; set; }
    }
}
