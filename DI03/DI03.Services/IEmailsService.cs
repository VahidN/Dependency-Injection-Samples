
namespace DI03.Services
{
    public interface IEmailsService
    {
        void SendEmailToUser(int userId, string subject, string body);
    }
}