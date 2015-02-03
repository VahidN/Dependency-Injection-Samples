using System;
using DI04.Services.Contracts;

namespace DI04.Services
{
    public class OrderHandlerNormal : IOrderHandler
    {
        private readonly IAccounting _accounting;
        private readonly ISales _sales;
        public OrderHandlerNormal(IAccounting accounting, ISales sales)
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