﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowcaseProduct.Models;
using ShowcaseProduct.Repository;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IPrixRepository prixRepository;
        public ProductController(IProductRepository productRepository, IPrixRepository prixRepository)
        {
            this.productRepository = productRepository;
            this.prixRepository = prixRepository;
        }
        // GET: /<controller>/
        public IActionResult ListProduct()
        {
            ViewData["listProduct"] = productRepository.GetAllProductFormulaires();
            return View();
        }
        // GET: /<controller>/
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductFormulaire model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Nom = model.Nom;
                product.Image = model.Image;
                product.Marque = model.Marque;
                productRepository.SaveProduct(ref product);
                Prix prix = new Prix();
                prix.PrixUniraire = model.PrixUniraire;
                prixRepository.SavePrix(ref prix);
                Relationprix relationprix = new Relationprix();
                relationprix.IdProduit = product.Id;
                relationprix.IdPrix = prix.Id;
                product.Relationprix.Add(relationprix);
                return RedirectToAction("ListProduct", "Product");
            }
            return View();
        }
        // GET: /<controller>/
        public IActionResult EditProduct(long id)
        {
            Product product = productRepository.GetProduct(id);
            Relationprix relationprix = new Relationprix();
            relationprix = product.Relationprix.Last();
            Prix prix = new Prix();
            prix = prixRepository.GetPrix(relationprix.IdPrix);
            ProductFormulaire mode = new ProductFormulaire(id, product.Nom, product.Image, product.Marque, prix.PrixUniraire);
            return View();
        }
        [HttpPost]
        public IActionResult EditProduct(ProductFormulaire model)
        {
            if (ModelState.IsValid)
            {
                Product product = productRepository.GetProduct(model.Id);
                product.Nom = model.Nom;
                product.Image = model.Image;
                product.Marque = model.Marque;
                productRepository.UpdateProduct(ref product);
                return RedirectToAction("ListProduct", "Product");
            }
            return View();
        }
    }
}
