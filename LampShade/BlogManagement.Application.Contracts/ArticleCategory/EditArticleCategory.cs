using System;
using System.Collections.Generic;
using System.Text;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class EditArticleCategory:CreateArticleCategory
    {
        public long Id { get; set; }
    }
}
