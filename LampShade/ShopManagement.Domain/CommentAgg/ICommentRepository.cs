﻿using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Comment;

namespace ShopManagement.Domain.CommentAgg
{
     public  interface ICommentRepository:IRepository<long,Comment>
     {
        List<CommentViewModel> GetList();
        EditComment GetDetails(long id);
        void Delete(Comment command);

     }
}
