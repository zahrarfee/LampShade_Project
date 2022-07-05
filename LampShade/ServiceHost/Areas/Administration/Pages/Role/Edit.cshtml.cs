using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using _0_Framework.Infrastracture;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Role
{
    public class EditModel : PageModel
    {
        public List<SelectListItem> Permissions=new List<SelectListItem>();
        public EditRole Command;
        
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;



        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }


        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    var group = new SelectListGroup { Name = key };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditRole command)
        {
            var role = _roleApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
