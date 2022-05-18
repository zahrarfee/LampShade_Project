using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository:RepositoryBase<long,Product> , IProductRepository


    {
        private readonly ShopContext _shopContext;


        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var product = _shopContext.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
              
                CategoryId = x.CategoryId,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                Category = x.Category.Name,
               

            });/*.Where(x => x.IsInStock == true);*/
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                product = product.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                product = product.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId!=0)
                product = product.Where(x => x.CategoryId==searchModel.CategoryId);
            
             return product.OrderByDescending(x => x.Id).ToList();

        }

        public EditProduct GetDetails(long id)
        {
            return _shopContext.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Code = x.Code,
                //Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                
                CategoryId = x.CategoryId,

                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                Keywords = x.Keywords
            }).FirstOrDefault(x => x.Id == id);
        }


        public void Remove(Product command)
        {
            _shopContext.Products.Remove(command);
            
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return _shopContext.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }
    }
}
