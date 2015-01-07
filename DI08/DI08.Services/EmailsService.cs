using System;

namespace DI08.Services
{
    public class EmailsService : IEmailsService, IDisposable
    {
        private bool _disposed;

        ~EmailsService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SendEmail()
        {
            //todo: send email!
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (_disposed) return;
            if (!disposeManagedResources) return;

            //todo: clean up resources here ...

            _disposed = true;
        }
    }
}