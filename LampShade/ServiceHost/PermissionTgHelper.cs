
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost
{
    [HtmlTargetElement(Attributes = "Permission")]
    public class PermissionTgHelper:TagHelper
    {
        private readonly IAuthHelper _authHelper;

        public PermissionTgHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public int Permission { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            var permission = _authHelper.GetPermissions();
            if (permission.All(x => x != Permission))
            {
                output.SuppressOutput();
                return;
            }
            base.Process(context, output);
        }
    }
}
