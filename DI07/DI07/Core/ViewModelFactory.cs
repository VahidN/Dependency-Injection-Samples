using System.Windows.Controls;

namespace DI07.Core
{
    /// <summary>
    /// Stitches together a view and its view-model
    /// </summary>
    public static class ViewModelFactory
    {
        public static void WireUp(this ContentControl control)
        {
            var viewName = control.GetType().Name;
            var viewModelName = string.Concat(viewName, "Model"); //قرار داد نامگذاري ما است
            control.Loaded += (s, e) =>
            {
                control.DataContext = SmObjectFactory.Container.GetInstance<IViewModel>(viewModelName);
            };
        }
    }
}