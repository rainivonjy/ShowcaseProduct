using Microsoft.AspNetCore.Http;
using ShowcaseProduct.Models.ConstApplication;
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
        public ProductFormulaire(long Id, string Nom, string Image, string Marque, double PrixUniraire, long IdPrix)
        :this(Id, Nom, Image, Marque, PrixUniraire)
        {
            this.IdPrix = IdPrix;
        }
        public ProductFormulaire(long Id, string Nom, string Image, string Marque, double PrixUniraire)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Image = Image;
            this.Marque = Marque;
            this.PrixUniraire = PrixUniraire;

        }
       

        [Required]
        [Display(Name = "Image")]
        public IFormFile FileImage { get; set; }
        public long IdPrix { get; set; }
    }
}
