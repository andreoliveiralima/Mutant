using System.Collections.Generic;
using TesteMutant.Model;

namespace TesteMutant.Interfaces
{
    public interface IIngredienteLanche
    {
        string Inserir(IngredienteLancheModel ingredienteLanche);
        string Excluir(int id);
        IEnumerable<IngredienteLancheModel> Buscar(int id);
    }
}
