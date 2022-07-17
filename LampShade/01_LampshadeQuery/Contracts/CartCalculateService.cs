using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using DiscountManagement.Infrastracture.EFCore;
using ShopManagement.Application.Contracts.Order;

namespace _01_LampshadeQuery.Contracts
{
    public class CartCalculateService:ICartCalculateService
    {
        private readonly IAuthHelper _authHelper;
        private readonly DiscountContext _discountContext;

        public CartCalculateService(DiscountContext discountContext, IAuthHelper authHelper)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart=new Cart();
            var colleagueDiscounts = _discountContext.CollegueDiscounts
                .Where(x=>!x.IsRemoved)
                .Select(x => new {x.DiscountRate, x.ProductId}).ToList();
            var customerDiscounts = _discountContext.CustomerDiscounts
                .Where(x=>x.StartDate<DateTime.Now && x.EndDate>DateTime.Now)
                .Select(x => new {x.DiscountRate, x.ProductId})
                .ToList();
            var currentAccountRole = _authHelper.CurrentAccountRole();
            //var discount=new DiscountHelper
            foreach (var item in cartItems)
            {
                if (currentAccountRole != Roles.SystemUser)
                {
                    var colleagueDiscount = colleagueDiscounts
                        .FirstOrDefault(x => x.ProductId == item.Id);
                    if (colleagueDiscount != null)
                        item.DiscountRate = colleagueDiscount.DiscountRate;


                }
                else
                {
                    var customerDiscount = customerDiscounts
                        .FirstOrDefault(x => x.ProductId == item.Id);
                    if (customerDiscount != null)
                        item.DiscountRate = customerDiscount.DiscountRate;


                }
                item.DiscountAmount = ((item.TotalItemPrice * item.DiscountRate) / 100);
                item.ItemPayAmount = item.TotalItemPrice - item.DiscountAmount;
                cart.Add(item);
            }

            return cart;
        }
    }


}
