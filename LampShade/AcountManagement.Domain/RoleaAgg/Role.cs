﻿using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.RoleaAgg
{
    public class Role : EntityBase
    {
        public string Name { get;private set; }
        public List<Account> Accounts { get; private set; }
        public List<Permission> Permissions { get; private set; }

        protected Role()
        {

        }
        public Role(string name , List<Permission> permissions)
        {
            Name = name;
            Accounts=new List<Account>();
            Permissions = permissions;
        }
        public void Edit(string name,List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}