
namespace DI06.Services.Contracts
{
    public interface IWebClientServices
    {
        string FetchUrl(string url);
        string GetWebPageTitle(string url);
    }
}
