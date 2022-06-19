using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.Comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string CreationDate { get; set; }
        public long ParentId { get; set; }
        public string Parent { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
