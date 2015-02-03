using System;
using DI04.Services.Contracts;

namespace DI04.Services
{
    public class Accounting : IAccounting
    {
        public Accounting()
        {
            Console.WriteLine("Accounting's ctor is called.");
        }

        public void CreateInvoice(int orderId, int count)
        {
            // ...
        }
    }
}