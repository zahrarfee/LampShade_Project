using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication:IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operationResult=new OperationResult();
            if (_productRepository.Exist(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var product=new Product(command.Name,command.Code,command.UnitPrice,command.ShortDescription,command.Description,command.Picture,command.PictureAlt,command.PictureTitle,slug,command.Keywords,command.MetaDescription,command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operationResult=new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product==null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            if (_productRepository.Exist(x => x.Name == command.Name && x.Id!=command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var slug = command.Slug.Slugify();
            product.Edit(command.Name,command.Code,command.UnitPrice,command.ShortDescription,command.Description,command.Picture,command.PictureAlt,command.PictureTitle,slug,command.Keywords,command.MetaDescription,command.CategoryId);
            _productRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Remove(EditProduct command)
        {
            var operationResult = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);

            _productRepository.Remove(product);
            _productRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public OperationResult InStock(long id)
        {
            var operationResult = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            product.InStock();
            _productRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult NotInStock(long id)
        {
            var operationResult = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            product.NotInStock();
            _productRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
