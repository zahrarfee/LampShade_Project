using System;
using System.Collections.Generic;
using System.Text;

namespace CommentManagement.Application.Contracts.Comment
{
    public class EditComment:CreateComment
    {
        public long Id { get; set; }
    }
}
