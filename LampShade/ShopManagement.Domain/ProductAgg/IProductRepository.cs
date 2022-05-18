using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long , Product>

    {
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
     
        void Remove(Product command);
        List<ProductViewModel> GetProducts();
        Product GetProductWithCategory(long id);

    }
}
