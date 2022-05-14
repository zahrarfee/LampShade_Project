using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productcategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productcategoryQuery)
        {
            _productcategoryQuery = productcategoryQuery;
        }


        public void OnGet(string id)
        {
            ProductCategory = _productcategoryQuery.GetCategoryWithProducts(id);
        }
    }
}
