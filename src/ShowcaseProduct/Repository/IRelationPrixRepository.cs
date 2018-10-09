using ShowcaseProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Repository
{
    public interface IRelationPrixRepository
    {
        void SaveRelationPrix(Relationprix product);
    }
}
