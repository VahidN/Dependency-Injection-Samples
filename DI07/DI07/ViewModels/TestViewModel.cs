using DI07.Services;
using DI07.Core;

namespace DI07.ViewModels
{
    public class TestViewModel : IViewModel // علامتگذاري ويوو مدل
    {
        private readonly ITestService _testService;
        public TestViewModel(ITestService testService) //تزريق وابستگي در سازنده كلاس
        {
            _testService = testService;
        }

        public string Data
        {
            get { return _testService.Test(); }
        }
    }
}