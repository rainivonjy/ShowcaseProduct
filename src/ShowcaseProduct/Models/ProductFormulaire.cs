using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class ProductFormulaire : Product
    {

        public double PrixUniraire { get; set; }
        public ProductFormulaire()
        {

        }
        public ProductFormulaire(long Id, string Nom, string Image, string Marque, double PrixUniraire)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Image = GetPath(Image);
            this.Marque = Marque;
            this.PrixUniraire = PrixUniraire;

        }
        public string GetPath(string NameImage)
        {
            return String.Concat(AllConstants.PathFolderImage, NameImage);
        }
    }
}
