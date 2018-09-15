using System;
using System.Collections.Generic;

namespace ShowcaseProduct.Models
{
    public partial class Commande
    {
        public long Id { get; set; }
        public long IdProduct { get; set; }
        public double? PrixUnitaire { get; set; }
        public double? PrixPromotionnel { get; set; }
        public long IdBonCommande { get; set; }
        public int Nombre { get; set; }

        public virtual BonCommande IdBonCommandeNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
