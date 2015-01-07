using System;
using System.Threading;
using DI05.Services;
using StructureMap;

namespace DI05.Core
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
                x.For<IUsersService>().Use<UsersService>();

                x.Policies.SetAllProperties(y =>
                {
                    y.OfType<IUsersService>();
                });
            });
        }
    }
}