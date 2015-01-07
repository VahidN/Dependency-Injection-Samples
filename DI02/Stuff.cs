using System;

namespace DI02
{
    public interface ICreditCard
    {
        string Charge();
    }

    public class Visa : ICreditCard
    {
        public string Charge()
        {
            return "Charging with the Visa!";
        }
    }

    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Swiping the MasterCard!";
        }
    }

    public class Shopper
    {
        private readonly ICreditCard creditCard;

        public Shopper(ICreditCard creditCard)
        {
            this.creditCard = creditCard;
        }

        public void Charge()
        {
            var chargeMessage = creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }
}