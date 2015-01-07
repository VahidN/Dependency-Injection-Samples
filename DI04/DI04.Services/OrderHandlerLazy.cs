using System;

namespace DI04.Services
{
    public class OrderHandlerLazy : IOrderHandler
    {
        private readonly Lazy<IAccounting> _accounting;
        private readonly Lazy<ISales> _sales;
        public OrderHandlerLazy(Lazy<IAccounting> accounting, Lazy<ISales> sales)
        {
            Console.WriteLine("OrderHandlerLazy ctor.");
            _accounting = accounting;
            _sales = sales;
        }

        public void Handle(int orderId, int count)
        {
            if (_sales.Value.ShippingAllowed(orderId))
            {
                _accounting.Value.CreateInvoice(orderId, count);
            }
        }
    }
}
