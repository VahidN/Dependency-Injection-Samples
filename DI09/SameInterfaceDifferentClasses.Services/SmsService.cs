using SameInterfaceDifferentClasses.Services.Contracts;

namespace SameInterfaceDifferentClasses.Services
{
    public class SmsService : IMessageService
    {
        public void Send(string message)
        {
            //todo: ...
        }
    }
}