using System;

namespace DI03.Services
{
    public class EmailsService: IEmailsService
    {
        private readonly IUsersService _usersService;
        public EmailsService(IUsersService usersService)
        {
            Console.WriteLine("EmailsService ctor.");
            _usersService = usersService;
        }

        public void SendEmailToUser(int userId, string subject, string body)
        {
            var email = _usersService.GetUserEmail(userId);
            Console.WriteLine("SendEmailTo({0})", email);
        }
    }
}