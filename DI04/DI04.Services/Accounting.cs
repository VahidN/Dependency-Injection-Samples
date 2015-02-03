using System;
using DI04.Services.Contracts;

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