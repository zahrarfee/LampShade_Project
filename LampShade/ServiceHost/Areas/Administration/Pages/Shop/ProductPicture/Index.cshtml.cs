using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        public List<ProductPictureViewModel> ProductPictures;
        public SelectList Products;
        public ProductPictureSearchModel SearchModel;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictures = _productPictureApplication.Search(searchModel);
            Products =new SelectList(_productApplication.GetProducts(),"Id", "Name"); 

        }

        public IActionResult OnGetCreate()
        {
            var command=new CreateProductPicture();
            command.Products = _productApplication.GetProducts();
            return Partial("./Create",command);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
           var productpicture=_productPictureApplication.Create(command);
            return new JsonResult(productpicture);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products = _productApplication.GetProducts();
            return Partial("./Edit",productPicture);
        }


        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var editedPicture = _productPictureApplication.Edit(command);

            return new JsonResult(editedPicture);
        }

        public IActionResult OnGetDelete(long id)
        {
            var pro = _productPictureApplication.GetDetails(id);
            return Partial("./Delete",pro);
        }

        public JsonResult OnPostDelete(EditProductPicture picture)
        {
           var pro= _productPictureApplication.Delete(picture);
            return new JsonResult(pro);
        }
    }
}
