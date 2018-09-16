using ShowcaseProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Repository
{
    public interface IProductRepository
    {
        void SaveProduct(ref Product product);
        IEnumerable<Product> GetAllProducts();
        List<ProductFormulaire> GetAllProductFormulaires();
        Product GetProduct(long id);
        void DeleteProduct(long id);
        void UpdateProduct(ref Product product);
    }
}
