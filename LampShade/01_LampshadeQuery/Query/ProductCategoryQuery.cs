using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01_LampshadeQuery.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery:IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetCategories()
        {
            return _shopContext.productCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug
                

            }).ToList();
        }
    }
}
