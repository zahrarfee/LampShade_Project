using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        
        public EditProduct Product;
        [TempData] public string Message { get; set; }
        public SelectList ProductCategories;
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(),"Id" , "Name");

        }

        public IActionResult OnGetCreate()
        {
            var command=new CreateProduct();
            command.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
           
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            Product = _productApplication.GetDetails(id);
            Product.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Edit", Product);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var product = _productApplication.Edit(command);
            return new JsonResult(product);
        }

        public IActionResult OnGetDelete(long id)
        {
            Product = _productApplication.GetDetails(id);

            //return RedirectToAction("./Index");
            return Partial("./Remove",Product);
        }
        public JsonResult OnPostDelete(EditProduct command)
        {
          var pro= _productApplication.Remove(command);
            return new JsonResult(pro);

        }

       
    }
}