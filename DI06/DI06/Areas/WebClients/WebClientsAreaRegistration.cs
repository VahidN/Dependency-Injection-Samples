using System.Web.Mvc;

namespace DI06.Areas.WebClients
{
    public class WebClientsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WebClients";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WebClients_default",
                "WebClients/{controller}/{action}/{id}",
                // تكميل نام كنترلر پيش فرض
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                // مشخص كردن فضاي نام مرتبط جهت جلوگيري از تداخل با ساير قسمت‌هاي برنامه
                namespaces: new[] { "DI06.Areas.WebClients.Controllers" }
            );
        }
    }
}