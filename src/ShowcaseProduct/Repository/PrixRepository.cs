using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowcaseProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace ShowcaseProduct.Repository
{
    public class PrixRepository : IPrixRepository
    {
        private product_baseContext context;
        private DbSet<Prix> prixtEntity;
        public PrixRepository(product_baseContext context)
        {
            this.context = context;
            prixtEntity = context.Set<Prix>();
        }
        public void DeletePrix(long id)
        {
            Prix prix = GetPrix(id);
            prixtEntity.Remove(prix);
            context.SaveChanges();
        }

        public IEnumerable<Prix> GetAllPrix()
        {
            return prixtEntity.AsEnumerable();
        }

        public Prix GetPrix(long id)
        {
            return prixtEntity.SingleOrDefault(p => p.Id == id);
        }

        public void SavePrix(ref Prix prix)
        {
            prixtEntity.Add(prix);
            context.SaveChanges();
        }

        public void UpdatePrix(ref Prix prix)
        {
            context.Entry(prix).State = EntityState.Modified;
            context.SaveChanges();
        }
        public PriceFormulaire GetPriceFormulaire(long id)
        {
            PriceFormulaire productFormulaire = (from p in context.Prix
                                                   where p.Id == id
                                                   join rp in context.Relationprix on p.Id equals rp.IdPrix
                                                   join pro in context.Product on rp.IdProduit equals pro.Id
                                                 select new PriceFormulaire(pro.Id, pro.Nom, p.Id, p.PrixUniraire)).FirstOrDefault();
            return productFormulaire;
        }
        public List<PriceFormulaire> GetAllPriceFormulaires()
        {
            var listProductFormulaire = (from p in context.Product
                                         join rp in context.Relationprix on p.Id equals rp.IdProduit
                                         join prix in context.Prix on rp.IdPrix equals prix.Id
                                         select new PriceFormulaire(p.Id, p.Nom, prix.Id, prix.PrixUniraire)).ToList();
            return listProductFormulaire;
        }
    }
}
