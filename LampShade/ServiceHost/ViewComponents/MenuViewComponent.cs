using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IArticleCategoryQuery _articleCategory;
        
        private readonly IProductCategoryQuery _productCategory;

        public MenuViewComponent(IProductCategoryQuery productCategory, IArticleCategoryQuery articleCategory)
        {
            _productCategory = productCategory;
            _articleCategory = articleCategory;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                ArticleCategories = _articleCategory.GetCategories(),
                ProductCategories = _productCategory.GetCategories()
            };
            return View(result);
        }
    }
}
