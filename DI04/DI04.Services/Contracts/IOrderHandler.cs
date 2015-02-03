
namespace DI04.Services.Contracts
{
    public interface IOrderHandler
    {
        void Handle(int orderId, int count);
    }
}