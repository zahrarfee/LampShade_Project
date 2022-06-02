using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
   public class CommentRepository:RepositoryBase<long,Comment>, ICommentRepository
   {
       private readonly ShopContext _context;

       public CommentRepository(ShopContext context):base(context)
       {
           _context = context;
       }

       public List<CommentViewModel> GetList()
       {
           return _context.Comments.Include(x=>x.Product).Select(x => new CommentViewModel
           {
               Id = x.Id,
               ProductId = x.ProductId,
               Product = x.Product.Name,
               Name = x.Name,
               Email = x.Email,
               Message = x.Message,
               IsConfirmed = x.IsConfirmed,
               CreationDate = x.CreationDate.ToFarsi()
           }).OrderByDescending(x => x.Id).ToList();
       }

       public EditComment GetDetails(long id)
       {
           return _context.Comments.Select(x => new EditComment
           {
               Id = x.Id,
               ProductId = x.ProductId,
               
               Name = x.Name,
               Email = x.Email,
               Message = x.Message,
               
               
           }).FirstOrDefault(x => x.Id == id);
       }

       public void Delete(Comment command)
       {
           _context.Comments.Remove(command);
       }
   }
}
