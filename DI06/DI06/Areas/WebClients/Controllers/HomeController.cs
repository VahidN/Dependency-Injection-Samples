using System.Web.Mvc;
using DI06.Services.Contracts;

namespace DI06.Areas.WebClients.Controllers
{
    public class HomeController : Controller
    {
        readonly IWebClientServices _webClientServices;
        public HomeController(IWebClientServices webClientServices)
        {
            _webClientServices = webClientServices;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
