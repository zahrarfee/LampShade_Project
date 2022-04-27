using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CollegueDiscount;
using DiscountManagement.Domain.CollegueDiscountAgg;

namespace DiscountManagement.Application
{
    public class CollegueDiscountApplication:ICollegueDiscountApplication
    {
        private readonly ICollegueDiscountRepository _collegueDiscount;

        public CollegueDiscountApplication(ICollegueDiscountRepository collegueDiscount)
        {
            _collegueDiscount = collegueDiscount;
        }

        public OperationResult Define(DefineCollegueDiscount command)
        {
            var operationResult=new OperationResult();
            if (_collegueDiscount.Exist(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var discount=new CollegueDiscount(command.ProductId,command.DiscountRate);
            _collegueDiscount.Create(discount);
            _collegueDiscount.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditCollegueDiscount command)
        {
            var operationResult = new OperationResult();
            var discount = _collegueDiscount.Get(command.Id);
            if (discount == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            if (_collegueDiscount.Exist(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
                discount.Edit(command.ProductId, command.DiscountRate);
            _collegueDiscount.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var discount = _collegueDiscount.Get(id);
            if (discount == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            discount.Remove();
            _collegueDiscount.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var discount = _collegueDiscount.Get(id);
            if (discount == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            discount.Restore();
            _collegueDiscount.SaveChange();
            return operationResult.Succeced();
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel)
        {
            return _collegueDiscount.Search(searchModel);
        }

        public EditCollegueDiscount GetDetails(long id)
        {
            return _collegueDiscount.GetDetails(id);
        }
    }
}
