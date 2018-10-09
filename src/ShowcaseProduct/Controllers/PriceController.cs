using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowcaseProduct.Models;
using ShowcaseProduct.Repository;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    public class PriceController : Controller
    {
        private IPrixRepository prixRepository;

        public PriceController(IPrixRepository prixRepository)
        {
            this.prixRepository = prixRepository;
        }
        // GET: /<controller>/
        public IActionResult ListPrice() 
        {
            ViewData["listPrix"] = prixRepository.GetAllPriceFormulaires();
            return View();
        }
        // GET: /<controller>/
        public IActionResult EditPrice(long id)
        {
            PriceFormulaire priceFormulaire = prixRepository.GetPriceFormulaire(id);
            return View(priceFormulaire);
        }
        [HttpPost]
        public IActionResult EditPrice(PriceFormulaire model)
        {
            if (ModelState.IsValid)
            {
                Prix prix = prixRepository.GetPrix(model.Id);
                prix.PrixUniraire = model.PrixUniraire;
                prix.PrixPromotionelle = model.PrixPromotionelle;
                prix.Datedebut = model.Datedebut;
                prix.DateFin = model.DateFin;
                prixRepository.UpdatePrix(ref prix);
                RedirectToAction("ListPrice","Price");
            }
            
            return View(model);
        }
    }
}
