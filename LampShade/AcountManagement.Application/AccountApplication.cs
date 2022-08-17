using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleaAgg;

namespace AccountManagement.Application
{
     public  class AccountApplication:IAccountApplication
     {
         private readonly IAuthHelper _authHelper;
         private readonly IPasswordHasher _hasher;
         private readonly IFileUploader _fileUploader;
         private readonly IRoleRepository _roleRepository;
         private readonly IAccountRepository _accountRepository;

         public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher hasher, IAuthHelper authHelper, IRoleRepository roleRepository)
         {
             _accountRepository = accountRepository;
             _fileUploader = fileUploader;
             _hasher = hasher;
             _authHelper = authHelper;
             _roleRepository = roleRepository;
         }

         public OperationResult Create(CreateAccount command)
        {
            var operationRessult=new OperationResult();
            if (_accountRepository.Exist(x => x.UserName == command.UserName || x.Mobile == command.Mobile))
                return operationRessult.Failed(ApplicationMessage.DublicatedRecord);
            var password = _hasher.Hash(command.Password);
            var picture = _fileUploader.Upload(command.ProfilePhoto, "ProfilePhoto");
            var account=new Account(command.FullName,command.UserName,password,command.Mobile,command.RoleId,picture);
            _accountRepository.Create(account);
            _accountRepository.SaveChange();
            return operationRessult.Succeced();

        }

        public OperationResult Edit(EditAccount command)
        {
            var operationRessult = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operationRessult.Failed(ApplicationMessage.RecordNotFound);
            var picture = _fileUploader.Upload(command.ProfilePhoto, "ProfilePhoto");
            
            account.Edit(command.FullName, command.UserName, command.Mobile, command.RoleId, picture);
            if (_accountRepository.Exist(x => (x.UserName == command.UserName || x.Mobile == command.Mobile )&& x.Id!=command.Id))
                return operationRessult.Failed(ApplicationMessage.DublicatedRecord);

            _accountRepository.SaveChange();
            return operationRessult.Succeced();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operationRessult = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operationRessult.Failed(ApplicationMessage.RecordNotFound);
            if (command.Password != command.Repassword)
                return operationRessult.Failed(ApplicationMessage.PasswordsNotMatch);
            var password = _hasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChange();
            return operationRessult.Succeced();
        }

        public OperationResult Login(Login command)
        {
            var operationRessult = new OperationResult();
            var account = _accountRepository.GetBy(command.UserName);
            if (account == null)
                return operationRessult.Failed(ApplicationMessage.WrongUserPass);
           var result = _hasher.Check(account.Password, command.Password);
           if (!result.Verified)
           {
               return operationRessult.Failed(ApplicationMessage.WrongUserPass);
           }

           var permissions = _roleRepository.Get(account.RoleId)
               .Permissions
               .Select(x => x.Code)
               .ToList();
           var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.FullName, account.UserName, account.Mobile,account.ProfilePhoto,permissions);
          
           _authHelper.SignIn(authViewModel);
           return operationRessult.Succeced();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public void Logout()
        {
          _authHelper.SignOut();
        }

        public List<AccountViewModel> GetProfilePhoto()
        {
          return  _accountRepository.GetProfilePhoto();
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                FullName = account.FullName,
                Mobile = account.Mobile
            };
        }
     }
}
