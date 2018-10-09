using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowcaseProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace ShowcaseProduct.Repository
{
    public class RelationPrixRepository : IRelationPrixRepository
    {
        private product_baseContext context;
        private DbSet<Relationprix> relationPrixEntity;
        public RelationPrixRepository(product_baseContext context)
        {
            this.context = context;
            relationPrixEntity = context.Set<Relationprix>();
        }
        public void SaveRelationPrix(Relationprix relationprix)
        {
            relationPrixEntity.Add(relationprix);
            context.SaveChanges();
        }
    }
}
