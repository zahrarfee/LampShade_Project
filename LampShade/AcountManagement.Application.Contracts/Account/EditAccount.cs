using System;
using System.Collections.Generic;
using System.Text;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Application.Contracts.Account
{
    public class EditAccount:CreateAccount
    {
        public long  Id { get; set; }
    }
}
