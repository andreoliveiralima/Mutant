using System.Collections.Generic;
using TesteMutant.Model;

namespace TesteMutant.Interfaces
{
    public interface ILanche 
    {
        string Inserir(LancheModel lanche);
        string Atualizar(LancheModel lanche);
        string Excluir(int id);
        IEnumerable<LancheModel> Listar();
        IEnumerable<LancheModel> ListarPrecos();
        IEnumerable<LancheModel> Buscar(int id);
        IEnumerable<IngredienteModel> BuscarIngredientes(int id);
    }
}
