namespace WinFormsIoc.Services
{
    public interface IEmailsService
    {
        void SendEmail(string from, string to, string title, string message);
    }
}