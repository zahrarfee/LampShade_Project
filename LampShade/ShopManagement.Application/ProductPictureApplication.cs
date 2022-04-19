using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication:IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
           var operationResult=new OperationResult();
           if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
               return operationResult.Failed(ApplicationMessage.DublicatedRecord);
           var productPicture=new ProductPicture(command.ProductId,command.Picture,command.PictureAlt,command.PictureTitle);
           _productPictureRepository.Create(productPicture);
           _productPictureRepository.SaveChange();
           return operationResult.Succeced();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound); 
            if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.Id != command.Id && x.ProductId==command.ProductId))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
           
            productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChange();
            return operationResult.Succeced();
                
               
           
           
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
          
            productPicture.Remove();
            _productPictureRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Delete(EditProductPicture picture)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(picture.Id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);

            _productPictureRepository.Remove(productPicture);
            _productPictureRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }
    }
}
