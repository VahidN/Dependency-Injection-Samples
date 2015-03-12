using System.Web.Mvc;
using DI06.Services.Contracts;

namespace DI06.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        readonly IWebClientServices _webClientServices;
        public UsersController(IWebClientServices webClientServices)
        {
            _webClientServices = webClientServices;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
