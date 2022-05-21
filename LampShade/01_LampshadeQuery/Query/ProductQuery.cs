using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using _01_LampshadeQuery.Contracts.ProductPicture;
using DiscountManagement.Infrastracture.EFCore;
using InventoryManagement.Infrastracture.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ProductQuery:IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        //public ProductQueryModel GetDetails(string slug)
        //{
        //    throw new NotImplementedException();
        //}

        public List<ProductQueryModel> GetLatestArrivals()
        {
            
            
                var inventories = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
                var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate });
                var products = _shopContext.Products.Include(x => x.Category)
                    
                    .Select(x => new ProductQueryModel
                    {
                        Id = x.Id,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        Picture = x.Picture,
                        Slug = x.Slug,
                        Name = x.Name,
                        Category = x.Category.Name,
                        CategorySlug = x.Category.Slug,




                    }).AsNoTracking().OrderByDescending(x=>x.Id).Take(6).ToList();
            
                    foreach (var product in products)
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


                    return products;
        }

        public List<ProductQueryModel> Search(string value)
        {
            var discounts = _discountContext.CustomerDiscounts.Select(x => new {x.ProductId, x.DiscountRate,x.EndDate}).ToList();
            var inventories = _inventoryContext.Inventories.Select(x => new {x.ProductId, x.UnitPrice}).ToList();
            var product = _shopContext.Products.Include(x=>x.Category).Select(x => new ProductQueryModel
            {
                Category = x.Category.Name,
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                Slug =x.Slug,
                ShortDescription = x.ShortDescription

            }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
            {
                product = product.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));
            }

            var products = product.OrderByDescending(x => x.Id).ToList();
            foreach (var item in products)
            {
                
                var inventory = inventories.FirstOrDefault(x => x.ProductId == item.Id);
                if (inventory != null)
                {
                    var price = inventory.UnitPrice;
                    item.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == item.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        item.DiscountRate = discountRate;
                        item.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        item.HasDiscount = discountRate > 0;

                        var discountAmount = Math.Round((price * discountRate) / 100);
                        item.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }

                }
                


            }

            return products;
        }

        public ProductQueryModel GetProductWithPictures(string slug)
        {
            var discounts  = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new {x.ProductId, x.DiscountRate,x.EndDate}).ToList();
            var inventories = _inventoryContext.Inventories.Select(x => new {x.ProductId, x.UnitPrice}).ToList();
            var product = _shopContext.Products.Include(x=>x.Category)
                .Include(x=>x.ProductPictureses).Select(x => new ProductQueryModel
            {
                Category = x.Category.Name,
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                Slug =x.Slug,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Code = x.Code,
                CategorySlug = x.Category.Slug,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                    ProductPictures = MapProductPicture(x.ProductPictureses)

                }).AsNoTracking().FirstOrDefault(x=>x.Slug==slug);
            if(product==null)
                return new ProductQueryModel();
            var inventory = inventories.FirstOrDefault(x => x.ProductId == product.Id);
            if (inventory != null)
            {
                var price = inventory.UnitPrice;
                product.Price = price.ToMoney();
                var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                if (discount != null)
                {
                    var discuntRate = discount.DiscountRate;
                    product.DiscountRate = discuntRate;
                    product.HasDiscount = discuntRate > 0;
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.DiscountRate = discuntRate;
                    var discountAmount = Math.Round((price * discuntRate) / 100);
                    product.PriceWithDiscount = (price - discountAmount).ToMoney();





                }
                

            }

            
            

            return product;
        }

        private static List<ProductPictureQueryModel> MapProductPicture(List<ProductPicture> ProductPictureses)
        {
            return ProductPictureses.Select(x => new ProductPictureQueryModel
            {
                ProductId = x.ProductId,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                IsRemoved = x.IsRemoved
            }).Where(x=>!x.IsRemoved).ToList();
        }
    }
    }