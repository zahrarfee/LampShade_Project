using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Infrastracture;

namespace AccountManagement.Application.Contracts.Role
{
    public class CreateRole
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }
}
