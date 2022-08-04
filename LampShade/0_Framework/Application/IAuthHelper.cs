using System;
using System.Collections.Generic;
using System.Text;

namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        bool IsAuthenticated();
        void SignIn(AuthViewModel account); //set cookie on response
        void SignOut();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        long CurrentAccountId();
    }
}
