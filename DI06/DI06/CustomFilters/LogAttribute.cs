using System.Web.Mvc;
using DI06.Services.Contracts;

namespace DI06.CustomFilters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public ILogActionService LogActionService { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogActionService.Log("......data......");
            base.OnActionExecuted(filterContext);
        }
    }
}