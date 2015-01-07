using DI04.Services;

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