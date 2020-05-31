using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteMutant.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<string> Inserir(T objeto);
        Task<string> Atualizar(T objeto);
        Task<string> Excluir(int id);
        Task<List<T>> Listar();
        Task<List<T>> Buscar(int id);
    }
}
