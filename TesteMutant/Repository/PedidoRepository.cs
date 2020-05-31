using Dapper;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using TesteMutant.Infra;
using TesteMutant.Interfaces;
using TesteMutant.Model;

namespace TesteMutant.Repository
{
    public class PedidoRepository : AcessoDados, IPedido
    {
        public IEnumerable<PedidoModel> Abrir()
        {
            try
            {
                var a =  ExecutarComRetorno<PedidoModel>("SP_PEDIDO_ABRIR", CommandType.StoredProcedure);
                return a;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }
        
        public string AtualizaPromocaoPedido(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return Executar("SP_PEDIDO_ATUALIZA_PROMOCAO", parameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public string Fechar(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return Executar("SP_PEDIDO_FECHAR", parameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public IEnumerable<PedidoModel> BuscarPedidoAberto()
        {
            try
            {
                return ExecutarComRetorno<PedidoModel>("SP_PEDIDO_BUSCAR_ABERTO", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public IEnumerable<PedidoModel> Buscar(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<PedidoModel>("SP_PEDIDO_BUSCAR", parameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Dispose();
            }
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


        ~PedidoRepository()
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
