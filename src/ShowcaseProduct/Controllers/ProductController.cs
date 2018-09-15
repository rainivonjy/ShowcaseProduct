using System;
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
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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
        // GET: /<controller>/
        public IActionResult EditProduct()
        {
            return View();
        }
    }
}
