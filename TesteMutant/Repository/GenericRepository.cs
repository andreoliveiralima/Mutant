using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TesteMutant.Interfaces;

namespace TesteMutant.Repository
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        public Task<string> Inserir(T objeto)
        {
            throw new NotImplementedException();
        }

        public Task<string> Atualizar(T objeto)
        {
            throw new NotImplementedException();
        }

        public Task<string> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Buscar(int id)
        {
            throw new NotImplementedException();
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


        ~GenericRepository()
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
