
namespace DI04.Services.Contracts
{
    public interface ISales
    {
        bool ShippingAllowed(int orderId);
    }
}