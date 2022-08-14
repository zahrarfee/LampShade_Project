using System;
using System.Collections.Generic;
using InventoryManagement.Application.Contract.Inventory;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infrastructure.Acl
{
    public class ShopInventoryAcl:IShopInventoryAcl
    {
        private IInventoryApplication _inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool ReduceFromInventory(List<OrderItem> items)
        {
            var command = new List<ReduceInventory>();
            foreach (var orderItem in items)
            { 
                var item = new ReduceInventory(orderItem.Count, orderItem.ProductId,orderItem.OrderId, "خرید مشتری");
                command.Add(item);
            }

            return _inventoryApplication.Reduce(command).IsSucceced;

        }
    }
}
