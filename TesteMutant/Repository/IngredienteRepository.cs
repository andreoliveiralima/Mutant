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
    public class IngredienteRepository : AcessoDados, IIngrediente
    {
        public string Inserir(IngredienteModel ingrediente)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NOME", ingrediente.nomeIngrediente, DbType.String, ParameterDirection.Input);
                parameters.Add("@VALOR", ingrediente.valorIngrediente, DbType.Double, ParameterDirection.Input);
                return Executar("SP_INGREDIENTES_INSERIR", parameters, CommandType.StoredProcedure);
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

        public string Atualizar(IngredienteModel ingrediente)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ingrediente.idIngrediente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@NOME", ingrediente.nomeIngrediente, DbType.String, ParameterDirection.Input);
                parameters.Add("@VALOR", ingrediente.valorIngrediente, DbType.Double, ParameterDirection.Input);
                return Executar("SP_INGREDIENTES_ATUALIZAR", parameters, CommandType.StoredProcedure);
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

        public string Excluir(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return Executar("SP_INGREDIENTES_EXCLUIR", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<IngredienteModel> Listar()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return ExecutarComRetorno<IngredienteModel>("SP_INGREDIENTES_LISTAR", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<IngredienteModel> Buscar(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<IngredienteModel>("SP_INGREDIENTES_BUSCAR", parameters, CommandType.StoredProcedure);
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


        ~IngredienteRepository()
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
