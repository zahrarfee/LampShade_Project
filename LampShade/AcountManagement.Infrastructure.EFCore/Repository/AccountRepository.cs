using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository:RepositoryBase<long,Account> , IAccountRepository
    {
        private readonly AccountContext _accountContext;
        public AccountRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query=_accountContext.Accounts
                .Include(x=>x.Role)
                .Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                UserName = x.UserName,
                RoleId = x.RoleId,
                CreationDate = x.CreationDate.ToFarsi(),
                Role =x.Role.Name

                
            });
            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                query = query.Where(x => x.FullName.Contains(searchModel.FullName));
            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));
            if (searchModel.RoleId>0)
                query = query.Where(x => x.RoleId==searchModel.RoleId);
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountContext.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                Password = x.Password,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
               
            }).FirstOrDefault(x=>x.Id==id);
        }

        public Account GetBy(string userName)
        {
            return _accountContext.Accounts.FirstOrDefault(x => x.UserName==userName);


        }

        public List<AccountViewModel> GetProfilePhoto()
        {
            return _accountContext.Accounts

                .Select(x => new AccountViewModel
                {
                    Id = x.Id,
                    ProfilePhoto = x.ProfilePhoto,
                    UserName = x.UserName,

                }).ToList();
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountContext.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName
            }).ToList();
        }
    }
}
