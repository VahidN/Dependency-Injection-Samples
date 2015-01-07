using System.Collections;
using System.Web;
using System.Web.UI;

namespace DI05.Core
{
    /// <summary>
    /// تسهيل در كار تزريق خودكار وابستگي‌ها در سطح فرم‌ها و يوزركنترل‌ها
    /// </summary>
    public class StructureMapModule : IHttpModule
    {
        public void Dispose()
        { }

        public void Init(HttpApplication app)
        {
            app.PreRequestHandlerExecute += (sender, e) =>
            {
                var page = HttpContext.Current.Handler as Page; // The Page handler
                if (page == null)
                    return;

                wireUpThePage(page);
                WireUpAllUserControls(page);
            };
        }

        private static void WireUpAllUserControls(Page page)
        {
            // در اينجا هم كار سيم كشي يوزر كنترل‌ها انجام مي‌شود
            page.InitComplete += (initSender, evt) =>
            {
                var thisPage = (Page)initSender;
                foreach (Control ctrl in getControlTree(thisPage))
                {
                    // فقط يوزر كنترل‌ها بررسي شدند
                    // اگر نياز است ساير كنترل‌هاي قرار گرفته روي فرم هم بررسي شوند شرط را حذف كنيد
                    if (ctrl is UserControl)
                    {
                        SmObjectFactory.Container.BuildUp(ctrl);
                    }
                }
            };
        }

        private static void wireUpThePage(Page page)
        {
            SmObjectFactory.Container.BuildUp(page); // برقراري خودكار سيم كشي‌ها در سطح صفحات
        }

        private static IEnumerable getControlTree(Control root)
        {
            foreach (Control child in root.Controls)
            {
                yield return child;
                foreach (Control ctrl in getControlTree(child))
                {
                    yield return ctrl;
                }
            }
        }
    }
}