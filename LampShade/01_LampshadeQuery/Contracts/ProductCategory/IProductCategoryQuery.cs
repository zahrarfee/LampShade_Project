using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetCategories();
        ProductCategoryQueryModel GetCategoryWithProducts(string slug);
        List<ProductCategoryQueryModel> GetCategoriesWithProducts();
    }
}
