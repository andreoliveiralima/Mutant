using System.Collections.Generic;
using TesteMutant.Model;

namespace TesteMutant.Interfaces
{
    public interface IItemPedido
    {
        IEnumerable<ItemPedidoModel> Inserir(ItemPedidoModel itemPedido);
        string AtualizarIngrediente(FecharPedidoModel itemPedidoIngrediente);
        string InserirIngrediente(ItemPedidoIngredienteModel itemPedidoIngrediente);
        IEnumerable<FecharPedidoModel> BuscarPorPedido(int id);
    }
}
