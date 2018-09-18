using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowcaseProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace ShowcaseProduct.Repository
{
    public class ProductRepository : IProductRepository
    {
        private product_baseContext context;
        private DbSet<Product> productEntity;
        public ProductRepository(product_baseContext context)
        {
            this.context = context;
            productEntity = context.Set<Product>();
        }
        public void DeleteProduct(long id)
        {
            Product product = GetProduct(id);
            productEntity.Remove(product);
            context.SaveChanges();
        }

        public List<ProductFormulaire> GetAllProductFormulaires()
        {
            var listProductFormulaire = (from p in context.Product
                                        join rp in context.Relationprix on p.Id equals rp.IdProduit
                                        join prix in context.Prix on rp.IdPrix equals prix.Id
                                        select new ProductFormulaire()).ToList();
            return listProductFormulaire;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productEntity.AsEnumerable();
        }

        public Product GetProduct(long id)
        {
            return productEntity.SingleOrDefault(p => p.Id == id);
        }

        public void SaveProduct(ref Product product)
        {
            productEntity.Add(product);
            context.SaveChanges();
        }
    
        
        public void UpdateProduct(ref Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
