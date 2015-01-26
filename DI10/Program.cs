using DI10.Services;

namespace DI10
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = SmObjectFactory.Container;
            var orderReceivedHandler = container.GetInstance<IHandler<OrderReceivedMessage>>();
            orderReceivedHandler.Handle(new OrderReceivedMessage { UserId = 10, ProductId = 12 });


            var orderCanceledHandler = container.GetInstance<IHandler<OrderCanceledMessage>>();
            orderCanceledHandler.Handle(new OrderCanceledMessage { OrderId = 11 });
        }
    }
}