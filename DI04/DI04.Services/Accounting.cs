using System;

namespace DI04.Services
{
    public class Accounting : IAccounting
    {
        public Accounting()
        {
            Console.WriteLine("Accounting ctor.");
        }

        public void CreateInvoice(int orderId, int count)
        {
            // ...
        }
    }
}