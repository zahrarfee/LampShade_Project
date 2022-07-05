using System;
using System.Collections.Generic;
using System.Text;

namespace _0_Framework.Application
{
    public class ApplicationMessage
    {
        public const string DublicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد،لطفا مجددا تلاش فرمائید";
        public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد،لطفا مجددا تلاش فرمایید";
        public const string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارد";
        public static string WrongUserPass = "نام کاربری یا کلمه عبور اشتباه است";
    }
}
