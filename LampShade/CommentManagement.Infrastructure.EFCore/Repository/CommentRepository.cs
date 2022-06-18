using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;


namespace CommentManagement.Infrastructure.EFCore.Repository
{
   public class CommentRepository:RepositoryBase<long,Comment>, CommentManagement.Domain.CommentAgg.ICommentRepository
    {
       private readonly CommentContext _context;

       public CommentRepository(CommentContext context):base(context)
       {
           _context = context;
       }

       public List<CommentViewModel> GetList()
       {
           return _context.Comments.Select(x => new CommentViewModel
           {
               Id = x.Id,
               OwnerRecordId = x.OwnerRecordId,
              
               Name = x.Name,
               Email = x.Email,
               Message = x.Message,
               Website = x.Website,
               Type = x.Type,
               IsConfirmed = x.IsConfirmed,
               CreationDate = x.CreationDate.ToFarsi()
           }).OrderByDescending(x => x.Id).ToList();
       }

       public EditComment GetDetails(long id)
       {
           return _context.Comments.Select(x => new EditComment
           {
               Id = x.Id,
               Name = x.Name,
               Email = x.Email,
               Message = x.Message,
               Website = x.Website,
               Type = x.Type,
               OwnerRecordId = x.OwnerRecordId,

               
               
           }).FirstOrDefault(x => x.Id == id);
       }

       public void Delete(Comment command)
       {
           _context.Comments.Remove(command);
       }
   }
}
