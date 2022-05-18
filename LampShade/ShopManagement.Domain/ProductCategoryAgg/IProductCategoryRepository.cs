using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long , ProductCategory>
    {
        //void Create(ProductCategory entity);
        //ProductCategory Get(long id);
        //List<ProductCategory> GetAll();
        //void SaveChange();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
        string GetSlugById(long id);

    }
}
