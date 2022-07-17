using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public const string CookieName = "cart-items";
        public List<CartItem> CartItems;
        public Cart Cart;
        private readonly IProductQuery _productQuery;
        private readonly ICartCalculateService _calculateService;

        public CheckOutModel(IProductQuery productQuery, ICartCalculateService calculateService)
        {
            _productQuery = productQuery;
            _calculateService = calculateService;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice();
              
            }
            //CartItems = _productQuery.GetInventoryStatus(cartItems);
            Cart = _calculateService.ComputeCart(cartItems); 

        }
    }
}
