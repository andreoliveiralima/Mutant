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
    public class ItemPedidoRepository : AcessoDados, IItemPedido
    {
        public IEnumerable<ItemPedidoModel> Inserir(ItemPedidoModel itemPedido)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDPEDIDO", itemPedido.idPedido, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@IDLANCHE", itemPedido.idLanche, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<ItemPedidoModel>("SP_ITEMPEDIDO_INSERIR", parameters, CommandType.StoredProcedure);
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

        public string InserirIngrediente(ItemPedidoIngredienteModel itemPedidoIngrediente)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDITEMPEDIDO", itemPedidoIngrediente.idItemPedido, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@IDINGREDIENTE", itemPedidoIngrediente.idIngrediente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VALOR", itemPedidoIngrediente.valor, DbType.Double, ParameterDirection.Input);
                parameters.Add("@QUANTIDADE", itemPedidoIngrediente.quantidade, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VALORDESCONTO", itemPedidoIngrediente.valorDesconto, DbType.Double, ParameterDirection.Input);
                return Executar("SP_ITEMPEDIDO_INSERIR_INGREDIENTE", parameters, CommandType.StoredProcedure);
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

        public string AtualizarIngrediente(FecharPedidoModel itemPedidoIngrediente)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", itemPedidoIngrediente.idItemPedidoIngrediente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@IDITEMPEDIDO", itemPedidoIngrediente.idItemPedido, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@IDINGREDIENTE", itemPedidoIngrediente.idIngrediente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VALOR", itemPedidoIngrediente.valor, DbType.Double, ParameterDirection.Input);
                parameters.Add("@QUANTIDADE", itemPedidoIngrediente.quantidade, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VALORDESCONTO", itemPedidoIngrediente.valorDesconto, DbType.Double, ParameterDirection.Input);
                return Executar("SP_ITEMPEDIDO_ATUALIZAR_INGREDIENTE", parameters, CommandType.StoredProcedure);
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



        public IEnumerable<FecharPedidoModel> BuscarPorPedido(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<FecharPedidoModel>("SP_ITEMPEDIDO_BUSCAR_POR_PEDIDO", parameters, CommandType.StoredProcedure);
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


        ~ItemPedidoRepository()
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
