namespace WinFormsIoc.IoC
{
    public static class IoCConfig
    {
        public static T Resolve<T>()
        {
            return SmObjectFactory.Container.GetInstance<T>();
        }
    }
}