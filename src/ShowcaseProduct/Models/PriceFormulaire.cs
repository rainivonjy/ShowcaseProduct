using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class PriceFormulaire : Prix
    {
        public long IdProduct { get; set; }
        public string Nom { get; set; }
        public PriceFormulaire()
        {
        }
        public PriceFormulaire(long IdProduct, string Nom)
        {
            this.IdProduct = IdProduct;
            this.Nom = Nom;
        }
        public PriceFormulaire(long IdProduct, string Nom, long Id, double PrixUniraire)
            :this(IdProduct, Nom)
        {
            this.Id = Id;
            this.PrixUniraire = PrixUniraire;
        }
    }
}
