using System;

namespace DI04.Services
{
    public class OrderHandler : IOrderHandler
    {
        private readonly IAccounting _accounting;
        private readonly ISales _sales;
        public OrderHandler(IAccounting accounting, ISales sales)
        {
            Console.WriteLine("OrderHandler ctor.");
            _accounting = accounting;
            _sales = sales;
        }

        public void Handle(int orderId, int count)
        {
            if (_sales.ShippingAllowed(orderId))
            {
                _accounting.CreateInvoice(orderId, count);
            }
        }
    }
}