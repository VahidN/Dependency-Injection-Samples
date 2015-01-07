
namespace DI05.Services
{
    public class UsersService: IUsersService
    {
        public string GetUserEmail(int id)
        {
            //فقط جهت بررسي تزريق وابستگي‌ها
            return "test@test.com";
        }
    }
}