using Microsoft.Win32.SafeHandles;
using System;
using System.Net;
using System.Runtime.InteropServices;


namespace TesteMutant.Infra
{
    public class Error : IDisposable
    {
        public HttpStatusCode httpStatus { get; set; }
        public string metodo { get; set; }
        public string detalhe { get; set; }

        public Error(HttpStatusCode _httpStatus, string _metodo, string _detalhe)
        {
            httpStatus = _httpStatus;
            metodo = _metodo;
            detalhe = _detalhe;
        }

        #region IDisposable Support
        private bool disposedValue = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposedValue = true;
        }


        ~Error()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}