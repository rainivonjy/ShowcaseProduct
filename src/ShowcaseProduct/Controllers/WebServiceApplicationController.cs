using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowcaseProduct.Repository;
using ShowcaseProduct.Models;
using Newtonsoft.Json;
using ShowcaseProduct.Models.ConstApplication;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WebServiceApplicationController : Controller
    {
        private IProductRepository productRepository;
        private IHostingEnvironment hostingEnvironment; 
        private IUtils utils; 
        public WebServiceApplicationController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment, IUtils utils)
        {
            this.utils = utils;
            this.productRepository = productRepository;
        }
      
        // GET: api/values
       [HttpPost]
        public ForJsonShopProducts GetShopProducts([FromBody]RequestShop requestShop)
        {
            ForJsonShopProducts shop;
            try
            {
                shop = productRepository.GetShopProductFormulaires(ref requestShop);
                shop.Error = new CustomError(Status.ok);
            }
            catch (Exception ex)
            {
                shop = new ForJsonShopProducts(new CustomError(Status.error, ex.Message));
            }
            return shop;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
