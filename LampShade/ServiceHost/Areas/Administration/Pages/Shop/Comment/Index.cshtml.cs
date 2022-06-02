using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Comment;

namespace ServiceHost.Areas.Administration.Pages.Shop.Comment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments;
        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetList();
        }

        public RedirectToPageResult OnGetConfirm(long id)
        {

            _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDelete(long id)
        {

            var comment = _commentApplication.GetDetails(id);
            return Partial("Delete",comment);
        }
        public JsonResult OnPostDelete(EditComment command)
        {

           var coment= _commentApplication.Delete(command);
            return new JsonResult(coment);
        }

    }
}
