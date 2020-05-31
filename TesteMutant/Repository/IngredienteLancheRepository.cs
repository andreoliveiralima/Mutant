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
    public class IngredienteLancheRepository : AcessoDados, IIngredienteLanche
    {
        public string Inserir(IngredienteLancheModel ingredienteLanche)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDLANCHE", ingredienteLanche.idLanche, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@IDINGREDIENTE", ingredienteLanche.idIngrediente, DbType.Int32, ParameterDirection.Input);
                return Executar("SP_INGREDIENTELANCHE_INSERIR", parameters, CommandType.StoredProcedure);
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
                return Executar("SP_INGREDIENTELANCHE_EXCLUIR", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<IngredienteLancheModel> Buscar(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<IngredienteLancheModel>("SP_INGREDIENTELANCHE_BUSCAR", parameters, CommandType.StoredProcedure);
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


        ~IngredienteLancheRepository()
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
