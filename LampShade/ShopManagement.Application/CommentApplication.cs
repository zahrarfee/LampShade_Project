using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }

        public OperationResult Create(CreateComment command)
        {
            var operationResult=new OperationResult();
            var comment=new Comment(command.Name,command.Email,command.Message,command.ProductId);
            if (comment == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            _commentRepository.Create(comment);
            _commentRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Delete(EditComment command)
        {
            var operationResult = new OperationResult();
            var comment = _commentRepository.Get(command.Id);
            if (comment == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            _commentRepository.Delete(comment);
            _commentRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Confirm(long id)
        {
            var operationResult = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            comment.Confirm();
            _commentRepository.SaveChange();
            return operationResult.Succeced();

        }

        public EditComment GetDetails(long id)
        {
            return _commentRepository.GetDetails(id);
        }
    }
}
