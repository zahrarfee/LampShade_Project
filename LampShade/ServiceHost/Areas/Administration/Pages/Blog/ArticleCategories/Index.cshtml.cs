using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories;
        public ArticleCategorySearchModel SearchModel;

        private readonly IArticleCategoryApplication _articleCategory;

        public IndexModel(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _articleCategory.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            
            return Partial("./Create",new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var category=_articleCategory.Create(command);
            return new JsonResult(category);
        }


        public IActionResult OnGetEdit(long id)
        {
            var category = _articleCategory.GetDetails(id);
            return Partial("./Edit", category);
        }

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var category = _articleCategory.Edit(command);
            return new JsonResult(category);
        }

        public IActionResult OnGetDelete(long id)
        {
            var category = _articleCategory.GetDetails(id);
            return Partial("Delete",category);
        }

        public JsonResult OnPostDelete(EditArticleCategory command)
        {
            var result = _articleCategory.Delete(command);
            return new JsonResult(result);
        }
    }
}
