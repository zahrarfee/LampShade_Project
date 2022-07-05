using _0_Framework.Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using AccountManagement.Domain.RoleaAgg;
using AccountManagement.Application.Contracts.Role;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository

    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;
        }

        public EditRole GetDetails(long id)
        {
            var role = _accountContext.Roles.Select(x => new EditRole
                {
                    Id = x.Id,
                    Name = x.Name,
                    MappedPermissions = MapPermissions(x.Permissions)
                }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();

            return role;

            
        }

        private static List<PermissionDto> MapPermissions(List<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code,x.Name)).ToList();
        }

        public List<RoleViewModel> GetList()
        {
            return _accountContext.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
