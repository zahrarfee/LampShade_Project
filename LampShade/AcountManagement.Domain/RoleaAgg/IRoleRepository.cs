using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Role;

namespace AccountManagement.Domain.RoleaAgg
{
    public interface IRoleRepository:IRepository<long, Role>
    {
        List<RoleViewModel> GetList();
        EditRole GetDetails(long id);
    }
}
