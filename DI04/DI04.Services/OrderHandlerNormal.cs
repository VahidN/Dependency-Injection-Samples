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
            Console.WriteLine("OrderHandler's ctor dependes on accounting and sales.");
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