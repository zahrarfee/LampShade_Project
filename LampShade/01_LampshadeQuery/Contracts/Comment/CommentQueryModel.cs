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
        public long ProductId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
