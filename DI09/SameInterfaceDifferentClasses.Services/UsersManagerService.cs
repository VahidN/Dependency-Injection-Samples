using SameInterfaceDifferentClasses.Services.Contracts;

namespace SameInterfaceDifferentClasses.Services
{
    public class UsersManagerService : IUsersManagerService
    {
        private readonly IMessageService _emailService;
        private readonly IMessageService _smsService;

        public UsersManagerService(IMessageService emailService, IMessageService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        public void ValidateUserByEmail(int id)
        {
            _emailService.Send("Validated.");
        }
    }
}