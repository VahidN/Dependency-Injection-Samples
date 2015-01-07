using SameInterfaceDifferentClasses.Services.Contracts;

namespace SameInterfaceDifferentClasses.Services
{
    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            // ...
        }
    }
}