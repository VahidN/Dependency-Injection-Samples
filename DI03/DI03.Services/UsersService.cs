using System;

namespace DI03.Services
{
    public class UsersService : IUsersService
    {
        private int _i;
        public UsersService()
        {
            //هدف صرفا نمايش وهله سازي خودكار اين وابستگي است
            Console.WriteLine("UsersService ctor.");
        }

        public string GetUserEmail(int userId)
        {
            _i++;
            Console.WriteLine("i:{0}", _i);
            //براي مثال دريافت از بانك اطلاعاتي و بازگشت يك نمونه جهت آزمايش برنامه
            return "name@site.com";
        }
    }
}