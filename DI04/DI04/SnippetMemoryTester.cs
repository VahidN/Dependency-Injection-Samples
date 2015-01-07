using System;

namespace DI04
{
    public class SnippetMemoryTester : IDisposable
    {
        private long totalMemBefore = GC.GetTotalMemory(true);

        public void Dispose()
        {
            long totalMemory = GC.GetTotalMemory(true);
           Console.WriteLine("Memory used: " + (totalMemory - this.totalMemBefore));
        }
    }
}