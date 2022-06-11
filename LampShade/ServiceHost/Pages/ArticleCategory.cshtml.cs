using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel ArticleCategory;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        public List<ArticleQueryModel> LatestArticles;
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _categoryQuery;

        public ArticleCategoryModel(IArticleCategoryQuery categoryQuery, IArticleQuery articleQuery)
        {
            _categoryQuery = categoryQuery;
            _articleQuery = articleQuery;
        }

        public void OnGet(string id)
        {
            ArticleCategory = _categoryQuery.GetArticleCategory(id);
            LatestArticles = _articleQuery.LatestArticles();
            ArticleCategories = _categoryQuery.GetCategories();

        }
    }
}
