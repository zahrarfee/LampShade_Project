using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using DiscountManagement.Application.Contracts.CollegueDiscount;
using DiscountManagement.Domain.CollegueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastracture.EFCore.Repository
{
    public class CollegueDiscountRepository:RepositoryBase<long, CollegueDiscount> , ICollegueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public CollegueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _context = discountContext;
            _shopContext = shopContext;
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var query = _context.CollegueDiscounts.Select(x => new CollegueDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            var discounts= query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount=>discount.Product=products.FirstOrDefault(x=>x.Id==discount.ProductId).Name);
            return discounts;
        }

        public EditCollegueDiscount GetDetails(long id)
        {
            return _context.CollegueDiscounts.Select(x => new EditCollegueDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
