using System;
using System.Collections.Generic;
using System.Text;

namespace CommentManagement.Application.Contracts.Comment
{
    public class CreateComment
    {
        public string Name { get;set; }
        public string Email { get;set; }
        public string Message { get;set; }
        public long OwnerRecordId { get;set; }
        public int Type { get;set; }
        public long ParentId { get; set; }
        
        public string Website { get;set; }
       

    }
}
