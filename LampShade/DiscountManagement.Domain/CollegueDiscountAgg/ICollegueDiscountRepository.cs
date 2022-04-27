using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using DiscountManagement.Application.Contracts.CollegueDiscount;

namespace DiscountManagement.Domain.CollegueDiscountAgg
{
    public interface ICollegueDiscountRepository:IRepository<long,CollegueDiscount>
    {
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel);
        EditCollegueDiscount GetDetails(long id);
    }
}
