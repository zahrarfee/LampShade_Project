using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using _01_LampshadeQuery.Contracts.ProductCategory;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        //public List<AccountViewModel> Photos;
        private readonly IArticleCategoryQuery _articleCategory;
        
        private readonly IProductCategoryQuery _productCategory;
        //private readonly IAccountApplication _accountApplication;

        public MenuViewComponent(IProductCategoryQuery productCategory, IArticleCategoryQuery articleCategory/*, IAccountApplication accountApplication*/)
        {
            _productCategory = productCategory;
            _articleCategory = articleCategory;
            //_accountApplication = accountApplication;
        }

        public IViewComponentResult Invoke()
        {
            //Photos = _accountApplication.GetProfilePhoto();
                var result = new MenuModel
            {
                
                ArticleCategories = _articleCategory.GetCategories(),
                ProductCategories = _productCategory.GetCategories()
            };
            return View(result);
        }
    }
}
