
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository:RepositoryBase<long , Order> , IOrderRepository
    {
        private readonly ShopContext _shopContext;

        public OrderRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public double GetAmountBy(long id)
        {
            return _shopContext.Orders.Select(x=>new {x.PayAmount,x.Id}).FirstOrDefault(x => x.Id == id).PayAmount;
        }
    }
}
