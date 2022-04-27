using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;

namespace DiscountManagement.Application.Contracts.CollegueDiscount
{
    public interface ICollegueDiscountApplication
    {
        OperationResult Define(DefineCollegueDiscount command);
        OperationResult Edit(EditCollegueDiscount command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel);
        EditCollegueDiscount GetDetails(long id);
    }
}
