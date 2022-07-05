using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleaAgg;

namespace AccountManagement.Application
{
    public class RoleApplication:IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operationResult = new OperationResult();
            if (_roleRepository.Exist(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var role=new Role(command.Name,new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditRole command)
        {
            var operationResult = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);

            if (_roleRepository.Exist(x => x.Name == command.Name && x.Id!=command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));
            role.Edit(command.Name ,permissions);
            _roleRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<RoleViewModel> GetList()
        {
            return _roleRepository.GetList();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }
    }
}
