using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using DI06.IocConfig;
using StructureMap.Web.Pipeline;
using DI06.CustomFilters;
using StructureMap;

namespace DI06
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;
        public StructureMapDependencyResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public  object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;

            return (!serviceType.IsAbstract && !serviceType.IsInterface && serviceType.IsClass)
                ? _container.GetInstance(serviceType)
                : _container.TryGetInstance(serviceType);
        }

        public  IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            initStructureMap();

            //اين مورد وارد فيلتر پروايدر نمي‌شود
            //GlobalFilters.Filters.Add(new LogAttribute());

            //اين مورد يك وهله‌ي سينگلتون را در ابتداي برنامه درست مي‌كند
            GlobalFilters.Filters.Add(SmObjectFactory.Container.GetInstance<LogAttribute>());

            //اين مورد هم يك وهله‌ي سينگلتون را در ابتداي برنامه درست مي‌كند
            //DependencyResolver.SetResolver(new StructureMapDependencyResolver(SmObjectFactory.Container));
            //GlobalFilters.Filters.Add(System.Web.Mvc.DependencyResolver.Current.GetService<LogAttribute>());
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