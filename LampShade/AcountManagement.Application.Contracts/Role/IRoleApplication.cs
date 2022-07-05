﻿using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
        List<RoleViewModel> GetList();
        EditRole GetDetails(long id);
    }
}
