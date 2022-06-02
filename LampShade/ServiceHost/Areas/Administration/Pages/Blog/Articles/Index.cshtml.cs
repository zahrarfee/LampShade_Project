
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        public EditArticle editarticle;
        public SelectList Categories;
        public List<ArticleViewModel> Articles;
        public ArticleSearchModel SearchModel;
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategory;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategory)
        {
            _articleApplication = articleApplication;
            _articleCategory = articleCategory;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Categories=new SelectList(_articleCategory.GetCategories(), "Id" , "Name");
            Articles = _articleApplication.Search(searchModel);
        }




        public IActionResult OnGetEdit(long id)
        {
            var article = _articleApplication.GetDetails(id);
            article.ArticleCategories = _articleCategory.GetCategories();

            return Partial("./Edit", article);
        }
        public JsonResult OnPostEdit(EditArticle command)
        {
            var article = _articleApplication.Edit(command);
            return new JsonResult(article);
        }


        public IActionResult OnGetDelete(long id)
        {
           var article = _articleApplication.GetDetails(id);

            return Partial("./Delete", article);
        }
        public JsonResult OnPostDelete(EditArticle command)
        {
           var result=_articleApplication.Delete(command);
            return new JsonResult(result);
        }

    }
}
