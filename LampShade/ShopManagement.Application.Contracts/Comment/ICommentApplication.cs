using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetList();
        OperationResult Create(CreateComment command);
        OperationResult Delete(EditComment command);
        OperationResult Confirm(long id);
        EditComment GetDetails(long id);
    }
}
