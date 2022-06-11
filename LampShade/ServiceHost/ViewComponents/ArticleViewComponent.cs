using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ArticleViewComponent:ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var articles = _articleQuery.LatestArticles();
            return View(articles);
        }
    }
}
