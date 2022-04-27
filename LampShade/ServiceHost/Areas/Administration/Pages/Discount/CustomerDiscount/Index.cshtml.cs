using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        public List<CustomerDiscountViewModel> CustomerDiscounts;
        public SelectList products;
        public CustomerDiscountSearchModel SearchModel;

        private readonly IProductApplication _product;
        
        private readonly ICustomerDiscountApplication _customer;

        public IndexModel(ICustomerDiscountApplication customer, IProductApplication product)
        {
            _customer = customer;
            _product = product;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            products=new SelectList(_product.GetProducts(),"Id" , "Name");
            CustomerDiscounts = _customer.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var discount=new DefineCustomerDiscount();
            discount.Products = _product.GetProducts();
            return Partial("Create",discount);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
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

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
           var dis= _customer.Edit(command);
            return new JsonResult(dis);
        }
    }
}
