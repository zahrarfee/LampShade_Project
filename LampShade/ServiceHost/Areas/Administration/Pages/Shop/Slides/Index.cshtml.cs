using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    //[Authorize(Roles = "1,2")]
    public class IndexModel : PageModel
    {
        public EditSlide editSlide;
        public List<SlideViewModel> Slides;
        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var comand=new CreateSlide();

            return Partial("Create",comand);
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var slide=_slideApplication.Create(command);
            return new JsonResult(slide);
        }

        public IActionResult OnGetEdit(long id)
        {
            editSlide = _slideApplication.GetDetails(id);
            return Partial("Edit", editSlide);

        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var slide = _slideApplication.Edit(command);
            return new JsonResult(slide);
        }

        public RedirectToPageResult OnGetRemove(long id)
        {
            _slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRestore(long id)
        {
            _slideApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
