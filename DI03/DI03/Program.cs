using DI03.Services;

namespace DI03
{
    class Program
    {
        static void Main(string[] args)
        {
            //نمونه‌اي از نحوه استفاده از تزريق وابستگي‌هاي خودكار
            var emailsService1 = SmObjectFactory.Container.GetInstance<IEmailsService>();
            emailsService1.SendEmailToUser(userId: 1, subject: "Test1", body: "Hello!");

            var emailsService2 = SmObjectFactory.Container.GetInstance<IEmailsService>();
            emailsService2.SendEmailToUser(userId: 1, subject: "Test2", body: "Hello!");
        }
    }
}