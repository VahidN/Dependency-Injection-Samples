using System;
using System.Threading;
using SameInterfaceDifferentClasses.Services;
using SameInterfaceDifferentClasses.Services.Contracts;
using StructureMap;

namespace SameInterfaceDifferentClasses
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
                // map same interface to different concrete classes
                ioc.For<IMessageService>().Use<SmsService>();
                ioc.For<IMessageService>().Use<EmailService>();

                ioc.For<IUsersManagerService>().Use<UsersManagerService>()
                   .Ctor<IMessageService>("smsService").Is<SmsService>()
                   .Ctor<IMessageService>("emailService").Is<EmailService>();
            });
        }
    }
}