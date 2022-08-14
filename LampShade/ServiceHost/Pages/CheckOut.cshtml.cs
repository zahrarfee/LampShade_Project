using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_LampshadeQuery.Contracts;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
       
        public const string CookieName = "cart-items";
        public List<CartItem> CartItems;
        public Cart Cart;
        private readonly IProductQuery _productQuery;
        private readonly ICartCalculateService _calculateService;
        private readonly ICartService _cartService;
        private readonly IOrderApplication _orderApplication;
        private readonly IZarinPalFactory _zarinpal;
        private readonly IAuthHelper _authHelper;

        public CheckOutModel(IProductQuery productQuery, ICartCalculateService calculateService, ICartService cartService, IOrderApplication orderApplication, IZarinPalFactory zarinpal, IAuthHelper authHelper)
        {
            _productQuery = productQuery;
            _calculateService = calculateService;
            _cartService = cartService;
            _orderApplication = orderApplication;
            _zarinpal = zarinpal;
            _authHelper = authHelper;
        }



        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            Cart = _calculateService.ComputeCart(cartItems);
            _cartService.Set(Cart);
        }

        
        public IActionResult OnPostPay(int sendMethod)
        {
            var cart = _cartService.Get();
            cart.SetSendMethod(sendMethod);
            //var orderId = _orderApplication.PlaceOrder(cart);
            if (sendMethod == 3)
            {
                cart.PayAmount +=  Convert.ToDouble(30000);

            }
                
            else
            {
                cart.PayAmount += Convert.ToDouble(15000);
            }
            
            var paymentResult = new PaymentResult();
            return RedirectToPage("/GettingCustomerInfo",
                paymentResult.Succeeded(
                    "", null, cart.PayAmount,cart.SendMethod));
        }

       
    }
}
