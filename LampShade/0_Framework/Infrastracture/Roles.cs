using System;
using System.Collections.Generic;
using System.Text;

namespace _0_Framework.Infrastracture
{
    public static class Roles
    {
        public const string Administration = "1";
        public const string Blogger = "2";
        public const string SystemUser = "4";

        public static  string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیر سیستم";
                case 2:
                    return "بلاگر";
                default:
                    return "";
            }

        }
    }
}
