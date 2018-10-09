using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    [Serializable]
    public class ForJsonShopProducts
    {
        public List<ProductFormulaire> ListProducts { set; get; }
        public CustomError Error { set; get; }
        public RequestShop SettingShop { set; get; }
        
        public ForJsonShopProducts()
        {
        }
        public ForJsonShopProducts(CustomError Error)
        {
            this.Error = Error;
        }
        public ForJsonShopProducts(List<ProductFormulaire> ListProducts)
        {
            this.ListProducts = ListProducts;
        }
    }
}
