
using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using AccountManagement.Domain.RoleaAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account:EntityBase
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account(string fullName, string userName, string password, string mobile, long roleId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            if (roleId == 0)
                RoleId = 4;
            ProfilePhoto = profilePhoto;

        }
        public void Edit(string fullName, string userName, string mobile, long roleId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            //password has changed in another class
            Mobile = mobile;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;

        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
