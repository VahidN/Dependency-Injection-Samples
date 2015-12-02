using System;
using System.Threading;
using DI08.Services;
using StructureMap;

namespace DI08
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
            var container = new Container(x =>
            {
                x.For<IEmailsService>().Use<EmailsService>();
            });
            container.AssertConfigurationIsValid();

            return container;
        }
    }
}