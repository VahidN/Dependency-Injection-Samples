using System.Web.Mvc;

namespace DI06.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                // تكميل نام كنترلر پيش فرض
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                // مشخص كردن فضاي نام مرتبط جهت جلوگيري از تداخل با ساير قسمت‌هاي برنامه
                namespaces: new[] { "DI06.Areas.Admin.Controllers" }
            );
        }
    }
}
