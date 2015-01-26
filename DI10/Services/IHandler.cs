namespace DI10.Services
{
    public interface IHandler<TEvent>
    {
        void Handle(TEvent args);
    }
}