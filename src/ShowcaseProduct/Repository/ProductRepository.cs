using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowcaseProduct.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

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
        public ForJsonShopProducts GetShopProductFormulaires(ref RequestShop requestShop)
        {
            Utils utils = new Utils();
            List<ProductFormulaire> listProductFormulaire = new List<ProductFormulaire>();
            if (requestShop.IsFirstRequest)
            {
                listProductFormulaire = (from p in context.Product
                                             join rp in context.Relationprix on p.Id equals rp.IdProduit
                                             join prix in context.Prix on rp.IdPrix equals prix.Id
                                             select new ProductFormulaire(p.Id, p.Nom, utils.CreatePathImg(p.Image.Trim(), true), p.Marque, prix.PrixUniraire)).ToList();

                requestShop.Total = listProductFormulaire.Count();
                if (listProductFormulaire.Count > requestShop.NbShow)
                {
                    int moduloPagination = listProductFormulaire.Count % requestShop.NbShow;
                    if (moduloPagination == 0)
                    {
                        requestShop.Pagination = listProductFormulaire.Count / requestShop.NbShow;
                        listProductFormulaire = listProductFormulaire.GetRange(0, requestShop.NbShow);
                    }
                    else
                    {
                        requestShop.Pagination = (listProductFormulaire.Count - moduloPagination) / requestShop.NbShow;
                        requestShop.Pagination++;
                    }
                }
                else
                {
                    requestShop.Pagination = 1;
                }
                listProductFormulaire = listProductFormulaire.GetRange(0,requestShop.NbShow);
                requestShop.CurrentPagination = 1;
                requestShop.CurrentTotal = requestShop.NbShow;
            }
            else
            {
                listProductFormulaire = (from p in context.Product
                                         join rp in context.Relationprix on p.Id equals rp.IdProduit
                                         join prix in context.Prix on rp.IdPrix equals prix.Id
                                         select new ProductFormulaire(p.Id, p.Nom, utils.CreatePathImg(p.Image.Trim(), true), p.Marque, prix.PrixUniraire))
                                         .Skip(requestShop.CurrentTotal).Take(requestShop.NbShow * requestShop.CurrentPagination).ToList();
                requestShop.CurrentTotal = requestShop.NbShow * requestShop.CurrentPagination;
            }
            requestShop.IsFirstRequest = true;
            ForJsonShopProducts forJsonShopProducts = new ForJsonShopProducts(listProductFormulaire);
            return forJsonShopProducts;
        }
        public List<ProductFormulaire> GetAllProductFormulaires()
        {
            Utils utils = new Utils();
            var listProductFormulaire = (from p in context.Product
                                        join rp in context.Relationprix on p.Id equals rp.IdProduit
                                        join prix in context.Prix on rp.IdPrix equals prix.Id
                                        select new ProductFormulaire(p.Id, p.Nom, utils.CreatePathImg(p.Image.Trim(),false), p.Marque, prix.PrixUniraire)).ToList();
            return listProductFormulaire;
        }
        public ProductFormulaire GetProductFormulaire(long id)
        {
            
            ProductFormulaire productFormulaire = (from p in context.Product
                                         where p.Id == id
                                         join rp in context.Relationprix on p.Id equals rp.IdProduit
                                         join prix in context.Prix on rp.IdPrix equals prix.Id
                                         
                                         select new ProductFormulaire(p.Id, p.Nom, p.Image, p.Marque, prix.PrixUniraire, prix.Id)).OrderByDescending(pf => pf.IdPrix).FirstOrDefault();
            return productFormulaire;
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
