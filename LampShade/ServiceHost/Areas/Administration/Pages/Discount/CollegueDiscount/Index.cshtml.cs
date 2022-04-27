using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CollegueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discount.CollegueDiscount
{
    public class IndexModel : PageModel
    {
        public List<CollegueDiscountViewModel> CollegueDiscounts;
        public SelectList products;
        public CollegueDiscountSearchModel SearchModel;

        private readonly IProductApplication _product;
        
        private readonly ICollegueDiscountApplication _customer;

        public IndexModel(ICollegueDiscountApplication customer, IProductApplication product)
        {
            _customer = customer;
            _product = product;
        }

        public void OnGet(CollegueDiscountSearchModel searchModel)
        {
            products=new SelectList(_product.GetProducts(),"Id" , "Name");
            CollegueDiscounts = _customer.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var discount=new DefineCollegueDiscount();
            discount.Products = _product.GetProducts();
            return Partial("Create",discount);
        }

        public JsonResult OnPostCreate(DefineCollegueDiscount command)
        {
            var dis = _customer.Define(command);
            return new JsonResult(dis);

        }

        public IActionResult OnGetEdit(long id)
        {
            var discount = _customer.GetDetails(id);
            discount.Products=_product.GetProducts();
          
            return Partial("Edit", discount);
        }

        public JsonResult OnPostEdit(EditCollegueDiscount command)
        {
           var dis= _customer.Edit(command);
            return new JsonResult(dis);
        }

        public RedirectToPageResult OnGetRemove(long id)
        {
            _customer.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRestore(long id)
        {
            _customer.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
