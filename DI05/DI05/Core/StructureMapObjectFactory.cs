using System;
using System.Threading;
using StructureMap;

namespace DI05.Core
{
    public static class StructureMapObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(() => new Container(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        public static void Initialize<T>() where T : Registry, new()
        {
            Container.Configure(cfg =>
            {
                cfg.AddRegistry<T>();
            });
        }
    }
}