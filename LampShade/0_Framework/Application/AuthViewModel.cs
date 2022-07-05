using System.Collections.Generic;

namespace _0_Framework.Application
{
    public  class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        
        public string ProfilePhoto { get; set; }
        public List<int> Permissions { get; private set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, long roleId, string fullName, string userName,string profilePhoto,List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            FullName = fullName;
            UserName = userName;
            ProfilePhoto = profilePhoto;
            Permissions = permissions;
        }
    }
}