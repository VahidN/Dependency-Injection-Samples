using System;

namespace DI04.Services
{
    public class Sales : ISales
    {
        public Sales()
        {
            Console.WriteLine("Sales ctor.");
        }

        public bool ShippingAllowed(int orderId)
        {
            // فقط جهت آزمايش سيستم
            return false;
        }
    }
}