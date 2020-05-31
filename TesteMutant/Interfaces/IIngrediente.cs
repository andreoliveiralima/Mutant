using System.Collections.Generic;
using TesteMutant.Model;

namespace TesteMutant.Interfaces
{
    public interface IIngrediente
    {
        string Inserir(IngredienteModel ingrediente);
        string Atualizar(IngredienteModel ingrediente);
        string Excluir(int id);
        IEnumerable<IngredienteModel> Listar();
        IEnumerable<IngredienteModel> Buscar(int id);
    }
}
