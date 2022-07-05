

using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository:IRepository<long,Account>
    {
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        EditAccount GetDetails(long id);
        Account GetBy(string userName);
        List<AccountViewModel> GetProfilePhoto();

    }
}
