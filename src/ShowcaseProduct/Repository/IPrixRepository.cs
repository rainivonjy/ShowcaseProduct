using ShowcaseProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Repository
{
    public interface IPrixRepository
    {
        void SaveProduct(Prix prix);
        IEnumerable<Prix> GetAllPrix();
        Prix GetPrix(long id);
        void DeletePrix(long id);
        void UpdatePrix(Prix prix);
    }
}
