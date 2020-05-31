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
    public class LancheRepository : AcessoDados, ILanche
    {
        public string Inserir(LancheModel lanche)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NOME", lanche.nomeLanche, DbType.String, ParameterDirection.Input);
                return Executar("SP_LANCHE_INSERIR", parameters, CommandType.StoredProcedure);
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

        public string Atualizar(LancheModel lanche)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", lanche.idLanche, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@NOME", lanche.nomeLanche, DbType.String, ParameterDirection.Input);
                return Executar("SP_LANCHE_ATUALIZAR", parameters, CommandType.StoredProcedure);
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
                return Executar("SP_LANCHE_EXCLUIR", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<LancheModel> Listar()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return ExecutarComRetorno<LancheModel>("SP_LANCHE_LISTAR", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<LancheModel> ListarPrecos()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return ExecutarComRetorno<LancheModel>("SP_LANCHE_PRECOS", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<LancheModel> Buscar(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<LancheModel>("SP_LANCHE_BUSCAR", parameters, CommandType.StoredProcedure);
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

        public IEnumerable<IngredienteModel> BuscarIngredientes(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                return ExecutarComRetorno<IngredienteModel>("SP_LANCHE_INGREDIENTES", parameters, CommandType.StoredProcedure);
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


        ~LancheRepository()
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
