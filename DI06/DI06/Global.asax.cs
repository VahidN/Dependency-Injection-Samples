using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using DI06.IocConfig;
using StructureMap.Web.Pipeline;
using DI06.CustomFilters;

namespace DI06
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            initStructureMap();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }

        private static void initStructureMap()
        {
            //Set current Controller factory as StructureMapControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            //Using the custom StructureMapFilterProvider
            var filterProvider = FilterProviders.Providers.Single(provider => provider is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(filterProvider);
            FilterProviders.Providers.Add(SmObjectFactory.Container.GetInstance<StructureMapFilterProvider>());
        }
    }

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                throw new InvalidOperationException(string.Format("Page not found: {0}", requestContext.HttpContext.Request.RawUrl));
            return SmObjectFactory.Container.GetInstance(controllerType) as Controller;
        }
    }
}