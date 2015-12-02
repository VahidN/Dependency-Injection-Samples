using System;
using System.Threading;
using DI07.Services;
using StructureMap;
using StructureMap.Graph;

namespace DI07.Core
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
            var container = new Container(cfg =>
            {
                cfg.For<ITestService>().Use<TestService>();

                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();

                    //scan.ConnectImplementationsToTypesClosing(typeof(ITestService))
                    //    .OnAddedPluginTypes(y => y.HybridHttpOrThreadLocalScoped());


                    // Add all types that implement IView into the container,
                    // and name each specific type by the short type name.
                    scan.AddAllTypesOf<IViewModel>().NameBy(type => type.Name);
                    scan.WithDefaultConventions();
                });
            });
            container.AssertConfigurationIsValid();

            return container;
        }
    }
}