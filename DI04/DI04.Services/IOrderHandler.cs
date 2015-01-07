
namespace DI04.Services
{
    public interface IOrderHandler
    {
        void Handle(int orderId, int count);
    }
}