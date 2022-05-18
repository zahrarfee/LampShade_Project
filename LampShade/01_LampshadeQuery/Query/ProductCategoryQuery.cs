using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using DiscountManagement.Infrastracture.EFCore;
using InventoryManagement.Infrastracture.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext, DiscountContext discountContext,
            InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }

        public List<ProductCategoryQueryModel> GetCategories()
        {
            return _shopContext.productCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug
            }).AsNoTracking().ToList();
        }

        public ProductCategoryQueryModel GetCategoryWithProducts(string slug)
        {
            var inventories = _inventoryContext.Inventories
                .Select(x => new {x.ProductId, x.UnitPrice}).ToList();


            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.ProductId, x.DiscountRate,x.EndDate});

            var category = _shopContext.productCategories.Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug,
                    Keywords = x.Keywords,
                    Products = MapProducts(x.Products)
                }).AsNoTracking().FirstOrDefault(x =>
                    x.Slug == slug);
            foreach (var product in category.Products)
            {
                var productInventory = inventories.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat(); 

                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return category;
        }


        public List<ProductCategoryQueryModel> GetCategoriesWithProducts()
        {
            var inventories = _inventoryContext.Inventories.Select(x => new {x.ProductId, x.UnitPrice}).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new {x.ProductId, x.DiscountRate,x.EndDate});
            var categories = _shopContext.productCategories.Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products)
                }).AsNoTracking().ToList();
            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var productInventory = inventories.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.Price = price.ToMoney();
                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount != null)
                        {
                            int discountRate = discount.DiscountRate;
                            product.DiscountRate = discountRate;
                           

                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            product.PriceWithDiscount = (price - discountAmount).ToMoney();
                        }
                    }
                }
            }

            return categories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> Products)
        {
            return Products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                Slug = x.Slug,
                Name = x.Name,
                Category = x.Category.Name
            }).ToList();
        }
    }
}