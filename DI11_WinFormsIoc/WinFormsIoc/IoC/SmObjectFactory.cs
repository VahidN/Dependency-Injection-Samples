using System;
using System.Threading;
using StructureMap;
using WinFormsIoc.Services;

namespace WinFormsIoc.IoC
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
            return new Container(cfg =>
            {
                cfg.For<IEmailsService>().Use<EmailsService>();
                cfg.For<IFormFactory>().Use<FormFactory>();
            });
        }
    }
}