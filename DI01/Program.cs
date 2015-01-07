
namespace DI01
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new Resolver();

            resolver.Register<Shopper, Shopper>();
            resolver.Register<ICreditCard, Visa>();

            var shopper = resolver.Resolve<Shopper>();
            shopper.Charge();
        }
    }
}