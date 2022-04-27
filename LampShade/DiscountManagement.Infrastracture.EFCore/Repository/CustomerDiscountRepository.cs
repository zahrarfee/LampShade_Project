using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastracture.EFCore.Repository
{
    public class CustomerDiscountRepository:RepositoryBase<long , CustomerDiscount> , ICustomerDiscountRepository
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _discountContext;
        public CustomerDiscountRepository(DiscountContext discountContext,ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _discountContext.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Reason = x.Reason,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi()
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();

            var query= _discountContext.CustomerDiscounts.Select(x => new CustomerDiscountViewModel()
            {
               
                Id = x.Id,
                Reason = x.Reason,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                ProductId = x.ProductId,
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                CreationDate = x.CreationDate.ToFarsi()
                
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.StartDate != null)
            {
                
                query = query.Where(x => x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());

            }
            if (searchModel.EndDate != null)
            {
                
                query = query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());

            }


            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount=>discount.Product=products.FirstOrDefault(x=>x.Id==discount.ProductId).Name);
            return discounts;
        }
    }
}
