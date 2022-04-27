using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository:RepositoryBase<long,ProductCategory>,IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

       

        

       

       

        

        public EditProductCategory GetDetails(long id)
        {
            return _shopContext.productCategories.Select(x=>new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
            }).FirstOrDefault(x =>x.Id==id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
           var query= _shopContext.productCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi()
                
     
            });
           if (!string.IsNullOrWhiteSpace(searchModel.Name))
               query = query.Where(x => x.Name.Contains(searchModel.Name));

           return query.OrderByDescending(x=>x.Id).ToList();
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _shopContext.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
