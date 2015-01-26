namespace DI10.Services
{
    public class OrderCanceledEvent : IHandler<OrderCanceledMessage>
    {
        public void Handle(OrderCanceledMessage args)
        {
            //todo: ... send an email
        }
    }
}