using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Account
{
    [Authorize(Roles = _0_Framework.Infrastracture.Roles.Administration)]
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel;
        public SelectList Roles;
        public List<AccountViewModel> Accounts;
        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.GetList(),"Id" ,"Name");
            Accounts = _accountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var account=new CreateAccount();
            account.Roles = _roleApplication.GetList();
            return Partial("./Create",account);
        }

        public JsonResult OnPostCreate(CreateAccount command)
        {
            var account=_accountApplication.Create(command);
            return new JsonResult(account);
        }

        public IActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetails(id);
            account.Roles = _roleApplication.GetList();
            return Partial("./Edit",account);
        }

        public JsonResult OnPostEdit(EditAccount command)
        {
            var account = _accountApplication.Edit(command);
            return new JsonResult(account);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword {Id = id};
            return Partial("ChangePassword",command);
        }

        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var account = _accountApplication.ChangePassword(command);
            return new JsonResult(account);
        }

    }
}
