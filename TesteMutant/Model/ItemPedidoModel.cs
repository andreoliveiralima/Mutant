using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteMutant.Model
{
    public class ItemPedidoModel
    {
        public int idItemPedido { get; set; }
        public int idPedido { get; set; }
        public int idLanche { get; set; }
        public List<ItemPedidoIngredienteModel> ingrediente { get; set; }
    }
}
