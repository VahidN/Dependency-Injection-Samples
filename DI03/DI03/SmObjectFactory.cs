using System;
using System.Threading;
using DI03.Services;
using StructureMap;

namespace DI03
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
                //x.For<IEmailsService>().Use<EmailsService>();
                //x.For<IUsersService>().Singleton().Use<UsersService>();
                x.Scan(scan =>
                {
                    scan.AssemblyContainingType<IEmailsService>();
                    scan.WithDefaultConventions();
                });
            });
        }
    }
}