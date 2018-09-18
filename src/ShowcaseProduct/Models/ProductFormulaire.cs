using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class ProductFormulaire : Product
    {
        [Required]
        [Display(Name = "Price")]
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

        [Required]
        [Display(Name = "Image")]
        public IFormFile FileImage { get; set; }
    }
}
