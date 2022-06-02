using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Comment;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        
        public ProductQueryModel ProductQuery;
        private readonly ICommentApplication _commentApplication;
        private readonly IProductQuery _productQuery;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            ProductQuery = _productQuery.GetProductWithPictures(id);
        }
        public RedirectToPageResult OnPost(CreateComment command,string productSlug)
        {
            var coment = _commentApplication.Create(command);
             return RedirectToPage("./Product", new {Id=productSlug});
        }


    }
}
