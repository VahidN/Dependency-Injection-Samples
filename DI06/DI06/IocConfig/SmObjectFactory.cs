using System;
using System.Threading;
using System.Web.Mvc;
using DI06.CustomFilters;
using DI06.Services;
using DI06.Services.Contracts;
using StructureMap;
using StructureMap.Pipeline;

namespace DI06.IocConfig
{
    public static class SmObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            return new Container(x =>
            {
                x.For<IWebClientServices>().Use<WebClientServices>();
                x.For<ILogActionService>().LifecycleIs<TransientLifecycle>().Use<LogActionService>();

                //x.For<IFilterProvider>().Use<StructureMapFilterProvider>();

                x.Policies.SetAllProperties(y =>
                {
                    y.OfType<ILogActionService>();
                });
            });
        }
    }
}