namespace TesteMutant.Model
{
    public class FecharPedidoModel
    {
        public int idItemPedido { get; set; }
        public int idPedido { get; set; }
        public int idLanche { get; set; }
        public int idIngrediente { get; set; }
        public int idItemPedidoIngrediente { get; set; }
        public double valor { get; set; }
        public double valorDesconto { get; set; }
        public int quantidade { get; set; }
        public string nomeLanche { get; set; }
        public string nomeProduto { get; set; }

    }
}
