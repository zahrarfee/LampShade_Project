using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategory;

        public MenuViewComponent(IProductCategoryQuery productCategory)
        {
            _productCategory = productCategory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
