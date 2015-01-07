using Microsoft.Practices.Unity;

namespace DI02
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<ICreditCard, MasterCard>();

            container.RegisterType<ICreditCard, MasterCard>(new InjectionProperty("propertyName", 5));

            var shopper = container.Resolve<Shopper>();
            shopper.Charge();
        }
    }
}