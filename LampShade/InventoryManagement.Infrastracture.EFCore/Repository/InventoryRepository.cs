using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastracture.EFCore.Repository
{
    public class InventoryRepository:RepositoryBase<long,Inventory> ,IInventoryRepository
    {
        private readonly ShopContext _shopContext; 
        private readonly InventoryContext _context;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _context = inventoryContext;
            _shopContext = shopContext;
        }

        public Inventory GetBy(long productId)
        {
            return _context.Inventories.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _context.Inventories.Select(x => new EditInventory
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Id = x.Id

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory = _context.Inventories.FirstOrDefault(x => x.Id == inventoryId);
            return inventory.InventoryOperations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Operation = x.Operation,
                Count = x.CurrentCount,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                OperationDate = x.OperationDate.ToFarsi(),
                Operator = "مدیر سیستم",
                OperatorId = x.OperatorId,
                OrderId = x.OrderId



            }).OrderByDescending(x=>x.Id).ToList();



        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var Products = _shopContext.Products.Select(x=>new {x.Id, x.Name}).ToList();
            var query = _context.Inventories.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentInventoryStock(),
                CreationDate = x.CreationDate.ToFarsi(),
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            if (searchModel.InStock)
                        query = query.Where(x => !x.InStock);
     

           
                
                var discounts = query.OrderByDescending(x => x.Id).ToList();
                discounts.ForEach(discount=>
                    {
                        discount.Product = Products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name;
                      
                    });
                 
                return discounts;
        }
    }
}
