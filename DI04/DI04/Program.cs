using DI04.Services;
using DI04.Services.Contracts;

namespace DI04
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mem = new SnippetMemoryTester())
            {
                var orderHandler = SmObjectFactory.Container.GetInstance<IOrderHandler>();
                orderHandler.Handle(orderId: 1, count: 10);
            }
        }
    }
}