using System;
using System.Threading;
using StructureMap;

namespace WinFormsWithPluginSupport.Core
{
    public static class IocConfig
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            var container = new Container(x =>
            {
                x.AddRegistry<PluginsRegistry>();
                // todo:  x.For<....>().Use<...>();
            });
            container.AssertConfigurationIsValid();

            return container;
        }
    }
}