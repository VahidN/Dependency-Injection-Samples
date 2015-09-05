using System.Web.Mvc;
using DI06.CustomFilters;
using DI06.Services.Contracts;

namespace DI06.Controllers
{
    public class MyBaseController : Controller
    {
        /// <summary>
        /// from http://forums.asp.net/t/1776480.aspx/1?ExecuteCore+in+base+class+not+fired+in+MVC+4+beta
        /// </summary>
        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }

        protected override void ExecuteCore()
        {
            base.ExecuteCore();
        }
    }

    public class HomeController : MyBaseController
    {
        readonly IWebClientServices _webClientServices;
        public HomeController(IWebClientServices webClientServices)
        {
            _webClientServices = webClientServices;
        }

        //[Log]
        public ActionResult Index()
        {
            // ViewBag.PageTitle = _webClientServices.GetWebPageTitle("http://www.dotnettips.info/");
            return View();
        }
    }
}