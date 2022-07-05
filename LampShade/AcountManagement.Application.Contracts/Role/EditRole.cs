using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Infrastracture;

namespace AccountManagement.Application.Contracts.Role
{
    public class EditRole:CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }
    }
}
