using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01_LampshadeQuery.Contracts.Chart;
using InventoryManagement.Infrastracture.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ChartQuery:IChartQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;

        public ChartQuery(ShopContext shopContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
        }

        public ChartViewModel GetProductForChart(long categoryId)
        {
            var inventories = _inventoryContext.Inventories.Select(x => new {x.ProductId, x.UnitPrice})
                .ToList();
            var category = _shopContext.productCategories
                .Include(x => x.Products)
                .Select(x => new ChartViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products)
                }).FirstOrDefault(x => x.Id == categoryId);

          
            if (category== null)
                return new ChartViewModel();
            category.Prices=new List<double>();
            foreach (var item in category.Products)
            {
                var inventory = inventories.FirstOrDefault(x => x.ProductId == item.Id);
                if (inventory!=null)
                {
                    item.Price = inventory.UnitPrice;
                    category.Prices.Add(item.Price);
                }
                
            }

            return category;
        }

        private static List<ChartItemViewModel> MapProducts(List<Product> products)
        {
            return products.Select(x => new ChartItemViewModel
            {
                Id = x.Id,
                
                

            }).ToList();
        }
    }
}
