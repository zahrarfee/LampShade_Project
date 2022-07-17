using System;
using System.Collections.Generic;
using System.Text;
using ShopManagement.Application.Contracts.Order;

namespace _01_LampshadeQuery.Contracts
{
    public interface ICartCalculateService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}
