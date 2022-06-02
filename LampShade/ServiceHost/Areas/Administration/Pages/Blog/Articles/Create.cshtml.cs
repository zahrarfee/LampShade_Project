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
    public class CreateModel : PageModel
    {
        public SelectList Categories;
        public CreateArticle Command;
        public List<ArticleViewModel> Articles;
        public ArticleSearchModel SearchModel;
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategory;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategory)
        {
            _articleApplication = articleApplication;
            _articleCategory = articleCategory;
        }
        public void OnGet()
        {
           
            Categories = new SelectList(_articleCategory.GetCategories(), "Id", "Name");

        }

        public RedirectToPageResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
