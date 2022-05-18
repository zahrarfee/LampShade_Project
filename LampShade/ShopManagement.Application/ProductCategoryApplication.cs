using System;
using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication:IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation=new OperationResult ();
            if (_productCategoryRepository.Exist(x=>x.Name==command.Name))
                return operation.Failed(ApplicationMessage.DublicatedRecord);
            var slug = command.Slug.Slugify();
         
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var productCategory=new ProductCategory(command.Name,command.Description,fileName,command.PictureTitle,command.PictureAlt,command.Keywords,command.MetaDescription,slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChange();
            return operation.Succeced();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult=new OperationResult();
            
            var categoryProduct = _productCategoryRepository.Get(command.Id);
            if (categoryProduct == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            if(_productCategoryRepository.Exist(x=>x.Name==command.Name && x.Id!=command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);
            categoryProduct.Edit(command.Name,command.Description,fileName,command.PictureTitle,command.PictureAlt,command.Keywords,command.MetaDescription,slug);
            _productCategoryRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }
    }
}
