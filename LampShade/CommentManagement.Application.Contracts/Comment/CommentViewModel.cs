using System;
using System.Collections.Generic;
using System.Text;

namespace CommentManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get;set; }
        public string Email { get;set; }
        public string Message { get;set; }
        
        
        public string Website { get; set; }
        public int Type { get; set; }
        public long OwnerRecordId { get; set; }
        
        public bool IsConfirmed { get;set; }

        public string CreationDate { get; set; }
       
        public string OwnerName  { get;set; }
    }
}
