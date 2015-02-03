using System;
using DI04.Services.Contracts;

namespace DI04.Services
{
    public class Sales : ISales
    {
        public Sales()
        {
            Console.WriteLine("Sales' ctor is called.");
        }

        public bool ShippingAllowed(int orderId)
        {
            // فقط جهت آزمايش سيستم
            return false;
        }
    }
}