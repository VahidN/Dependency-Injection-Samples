using StructureMap;
using WinFormsIoc.Services;

namespace WinFormsIoc.IoC
{
    public static class IoCConfig
    {
        public static void Bootstrap()
        {
            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IEmailsService>().Use<EmailsService>();
                cfg.For<IFormFactory>().Use<FormFactory>();
            });
        }

        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
