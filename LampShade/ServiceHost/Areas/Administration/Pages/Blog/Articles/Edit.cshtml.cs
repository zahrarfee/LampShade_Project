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
    public class EditModel : PageModel
    {
        public EditArticle Command;
        public SelectList Categories;
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategory;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategory)
        {
            _articleApplication = articleApplication;
            _articleCategory = articleCategory;
        }

        public void OnGet (long id)
        {
            Command = _articleApplication.GetDetails(id);
            
            Categories=new SelectList(_articleCategory.GetCategories(),"Id","Name");
        }

        public RedirectToPageResult OnPost(EditArticle command)
        {
            _articleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
