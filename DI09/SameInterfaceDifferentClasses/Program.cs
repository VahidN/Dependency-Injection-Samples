using SameInterfaceDifferentClasses.Services.Contracts;

namespace SameInterfaceDifferentClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersManagerService = SmObjectFactory.Container.GetInstance<IUsersManagerService>();
            usersManagerService.ValidateUserByEmail(id: 1);
        }
    }
}
