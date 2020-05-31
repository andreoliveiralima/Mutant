using System;
using System.Collections.Generic;
using System.Linq;
using TesteMutant.Interfaces;
using TesteMutant.Model;

namespace TesteMutant.Business
{
    public class PromocaoBusiness
    {
        //=============================================================
        //usar neste enum o id do ingrediente no banco
        //=============================================================
        enum eIngrediente
        {
            Alface = 2,
            Bacon = 3,
            Hamburger = 4,
            Ovo = 5,
            Queijo = 6
        }

        private readonly IItemPedido _IItemPedido;
        private readonly IPedido _IPedido;

        public PromocaoBusiness(IItemPedido IItemPedido, IPedido IPedido)
        {
            _IItemPedido = IItemPedido;
            _IPedido = IPedido;
        }

        public string AplicaPromocao(int id)
        {
            try
            {
                var retorno = _IItemPedido.BuscarPorPedido(id);
                if (retorno.Count() > 0)
                {
                    var lanches = from ret in retorno group ret by ret.idItemPedido into retGroup select retGroup.Key;
                    foreach (var lanche in lanches)
                    {
                        List<FecharPedidoModel> itensLanche = retorno.Where(x => x.idItemPedido == lanche).ToList();

                        promocaoLight(itensLanche);
                        promocaoCarne(itensLanche);
                        promocaoQueijo(itensLanche);
                    }

                    _IPedido.AtualizaPromocaoPedido(id);
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception(ex.Message);
            }
        }

        public void promocaoLight(List<FecharPedidoModel> itensLanche)
        {
            var alface = itensLanche.Where(x => x.idIngrediente == Convert.ToInt32(eIngrediente.Alface)).ToList();
            var bacon = itensLanche.Where(x => x.idIngrediente == Convert.ToInt32(eIngrediente.Bacon)).ToList();
            if (alface.Count > 0 && bacon.Count == 0)
            {
                foreach (var item in itensLanche)
                {
                    item.valorDesconto = item.valorDesconto + Math.Round((item.valor * 0.1), 2);
                    _IItemPedido.AtualizarIngrediente(item);
                }
            }
        }

        public void promocaoCarne(List<FecharPedidoModel> itensLanche)
        {
            foreach (var item in itensLanche)
            {
                if (item.idIngrediente == Convert.ToInt32(eIngrediente.Hamburger))
                {
                    int desconto = (int)(item.quantidade / 3);
                    if (desconto > 0)
                    {
                        item.valorDesconto = item.valorDesconto + Math.Round((item.valor * desconto), 2);
                        _IItemPedido.AtualizarIngrediente(item);
                    }
                }
            }
        }

        public void promocaoQueijo(List<FecharPedidoModel> itensLanche)
        {
            foreach (var item in itensLanche)
            {
                if (item.idIngrediente == Convert.ToInt32(eIngrediente.Queijo))
                {
                    int desconto = (int)(item.quantidade / 3);
                    if (desconto > 0)
                    {
                        item.valorDesconto = item.valorDesconto + Math.Round((item.valor * desconto), 2);
                        _IItemPedido.AtualizarIngrediente(item);
                    }
                }


            }
        }

    }
}
