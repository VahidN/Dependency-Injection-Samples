namespace PluginsBase
{
    public interface IPlugin
    {
        string Name { get; }
        void Run();
    }
}