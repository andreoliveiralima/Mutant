using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteMutant.Model
{
    public class ItemPedidoIngredienteModel
    {
        public int idItemPedidoIngrediente { get; set; }
        public int idItemPedido { get; set; }
        public int idIngrediente { get; set; }
        public double valor { get; set; }
        public double valorDesconto { get; set; }
        public int quantidade { get; set; }
        public string nomeIngrediente { get; set; }
    }
}
