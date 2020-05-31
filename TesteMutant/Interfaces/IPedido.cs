using System.Collections.Generic;
using TesteMutant.Model;

namespace TesteMutant.Interfaces
{
    public interface IPedido
    {
        IEnumerable<PedidoModel> Abrir();
        string Fechar(int id);
        string AtualizaPromocaoPedido(int id);
        IEnumerable<PedidoModel> Buscar(int id);
        IEnumerable<PedidoModel> BuscarPedidoAberto();
    }
}
