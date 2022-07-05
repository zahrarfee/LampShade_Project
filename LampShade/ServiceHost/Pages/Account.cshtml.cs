using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }
        private IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

   
        public IActionResult OnPostLogin(Login command)
        {
            var result= _accountApplication.Login(command);
            if (result.IsSucceced)
                return RedirectToPage("/Index");

            LoginMessage = result.Message;
            return RedirectToPage("/Login");
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public RedirectToPageResult OnPostRegister(CreateAccount command)
        {
            var account=_accountApplication.Create(command);
            if(account.IsSucceced)
                return RedirectToPage("/Account");
            RegisterMessage = account.Message;
            return RedirectToPage("/Account");

        }

    }
}
