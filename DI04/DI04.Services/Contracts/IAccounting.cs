
namespace DI04.Services.Contracts
{
    public interface IAccounting
    {
        void CreateInvoice(int orderId, int count);
    }
}
