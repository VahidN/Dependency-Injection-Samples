namespace DI10.Services
{
    public class OrderReceivedEvent : IHandler<OrderReceivedMessage>
    {
        public void Handle(OrderReceivedMessage args)
        {
            //todo: ... send an email
        }
    }
}