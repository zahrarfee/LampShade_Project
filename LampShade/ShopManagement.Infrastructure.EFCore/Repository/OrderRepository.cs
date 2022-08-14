
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository:RepositoryBase<long , Order> , IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public OrderRepository(ShopContext shopContext, AccountContext accountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public double GetAmountBy(long id)
        {
            return _shopContext.Orders.Select(x=>new {x.PayAmount,x.Id}).FirstOrDefault(x => x.Id == id).PayAmount;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var accounts = _accountContext.Accounts.Select(x => new {x.FullName,x.Id }).ToList();
      
            var query=_shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                AccountId = x.AccountId,
                DiscountAmount = x.DiscountAmount,
                IsCanceled = x.IsCanceled,
                IsPayed = x.IsPayed,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                PaymentMethodId = x.PaymentMethod,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi()
            });
            
            query = query.Where(x => x.IsCanceled == searchModel.IsCanceled);
            if (searchModel.AccountId > 0)
                query = query.Where(x => x.AccountId == searchModel.AccountId);
            var orders = query.OrderByDescending(x => x.Id).ToList();
            foreach (var item in orders)
            {
                item.AccountFullName = accounts.FirstOrDefault(x => x.Id == item.AccountId)?.FullName;
                item.PaymentMethod = PaymentMethod.GetBy(item.PaymentMethodId).Name;
            }

            return orders;

        }

        public List<OrderItemViewModel> GetItems(long orderId)
        {
            var product = _shopContext.Products.Select(x => new {x.Id,x.Name }).ToList();
            var orders = _shopContext.Orders.FirstOrDefault(x => x.Id == orderId);
            var items=orders.Items
                .Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    Count = x.Count,
                    DiscountRate = x.DiscountRate,
                    UnitPrice = x.UnitPrice,
                    ProductId = x.ProductId,
                    OrderId = x.OrderId
                }).ToList();
            foreach (var item in items)
            {
                item.Product = product.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items;
        }
    }
}
