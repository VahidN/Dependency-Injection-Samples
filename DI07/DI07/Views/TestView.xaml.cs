using DI07.Core;

namespace DI07.Views
{
    public partial class TestView
    {
        public TestView()
        {
            InitializeComponent();
            this.WireUp(); //تزريق خودكار وابستگي‌ها و يافتن ويوو مدل متناظر
        }
    }
}