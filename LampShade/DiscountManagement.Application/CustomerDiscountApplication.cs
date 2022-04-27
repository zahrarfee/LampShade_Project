using System;
using System.Collections.Generic;
using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication:ICustomerDiscountApplication

    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operationResult=new OperationResult();
            if (_customerDiscountRepository.Exist(x=>x.ProductId==command.ProductId && x.DiscountRate==command.DiscountRate))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            var discount=new CustomerDiscount(command.ProductId,command.DiscountRate,startDate,endDate,command.Reason);
            _customerDiscountRepository.Create(discount);
            _customerDiscountRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operationResult = new OperationResult();
           
            var discount = _customerDiscountRepository.Get(command.Id);
            if (discount == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            discount.Edit(command.ProductId, command.DiscountRate, startDate, endDate, command.Reason);
            _customerDiscountRepository.SaveChange();
            return operationResult.Succeced();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
