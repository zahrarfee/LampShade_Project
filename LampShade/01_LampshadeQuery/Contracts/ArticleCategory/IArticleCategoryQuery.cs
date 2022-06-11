using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryQueryModel> GetCategories();
        ArticleCategoryQueryModel GetArticleCategory(string slug);
    }
}
