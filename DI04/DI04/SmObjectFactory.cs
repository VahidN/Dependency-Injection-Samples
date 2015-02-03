using System;
using System.Threading;
using DI04.Services;
using DI04.Services.Contracts;
using StructureMap;

namespace DI04
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
                x.For<IOrderHandler>().Use<OrderHandlerLazy>();

                x.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<IOrderHandler>();
                    // connects `IAccounting` to `Accounting` and `ISales` to `Sales` automatically.
                    scanner.WithDefaultConventions();
                });

                // Manual lazy loading settings
                //x.For<Lazy<IAccounting>>().Use(c => new Lazy<IAccounting>(c.GetInstance<Accounting>));
                //x.For<Lazy<ISales>>().Use(c => new Lazy<ISales>(c.GetInstance<Sales>));
            });
        }
    }
}