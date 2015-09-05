using System.Web.Mvc;
using DI06.Services.Contracts;
using StructureMap;

namespace DI06.CustomFilters
{
    public class LogAttribute : ActionFilterAttribute
    {
        private readonly IContainer _container;

        //����� �� ��� ���� ����� ��� ��� �� �������� ������ ��� ����� ���� ���� ����� ��
        //public ILogActionService LogActionService { get; set; }

        public LogAttribute(IContainer container)
        {
            _container = container;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _container.GetInstance<ILogActionService>().Log("......data......");
            //LogActionService.Log("......data......");
            base.OnActionExecuted(filterContext);
        }
    }
}