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
            context.Entry(prix).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdatePrix(ref Prix prix)
        {
            context.Entry(prix).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
