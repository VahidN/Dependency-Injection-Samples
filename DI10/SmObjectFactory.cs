using System;
using System.Threading;
using DI10.Services;
using StructureMap;

namespace DI10
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
            return new Container(ioc =>
            {
                ioc.Scan(cfg =>
                {
                    cfg.AssemblyContainingType(typeof(IHandler<>));
                    cfg.ConnectImplementationsToTypesClosing(typeof(IHandler<>));
                });
            });
        }
    }
}