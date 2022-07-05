using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Role
{
    [Authorize(Roles =_0_Framework.Infrastracture.Roles.Administration)]
    public class IndexModel : PageModel
    {
        public List<RoleViewModel> Roles;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = _roleApplication.GetList();
        }




    

        
    }
}
