using System;
using System.Collections.Generic;
using TesteMutant.Business;
using TesteMutant.Model;
using TesteMutant.Repository;
using Xunit;

namespace TestMutant.Tests
{
    public class TesteUnitario
    {
        [Theory]
        [InlineData(new double[]{ 6.5, 4.5, 5.3, 7.3 })]
        public void TestaValoresLanches(double[] valoresEsperados)
        {
            //Arrange
            LancheRepository repo = new LancheRepository();

            //Act
            var resultado = repo.ListarPrecos();

            //Assert

            int index = 0;
            foreach(var item in resultado)
            {
                Assert.Equal(item.valor, valoresEsperados[index]);
                index++;
            }

        }

        [Fact]
        public void TestaRegraPromocoesLight()
        {
            //Arrange
            PedidoRepository pedidoRepo = new PedidoRepository();
            ItemPedidoRepository itemRepo = new ItemPedidoRepository();

            FecharPedidoModel alface = new FecharPedidoModel() {
                idItemPedido = 10,
                idPedido = 4,
                idLanche = 2,
                idIngrediente = 2,
                idItemPedidoIngrediente = 1,
                valor = 0.40,
                quantidade = 1,
                nomeLanche = "X-Bacon"
            };


            PromocaoBusiness promocaoBussiness = new PromocaoBusiness(itemRepo, pedidoRepo);


            //Act
            promocaoBussiness.promocaoLight(new List<FecharPedidoModel>() { alface });

            //Assert
            Assert.Equal(alface.valorDesconto, 0.04);

        }

        [Fact]
        public void TestaRegraPromocaoCarne()
        {
            //Arrange
            PedidoRepository pedidoRepo = new PedidoRepository();
            ItemPedidoRepository itemRepo = new ItemPedidoRepository();

            FecharPedidoModel hamburger = new FecharPedidoModel()
            {
                idItemPedido = 10,
                idPedido = 4,
                idLanche = 2,
                idIngrediente = 4,
                idItemPedidoIngrediente = 1,
                valor = 3,
                quantidade = 10,
                nomeLanche = "X-Bacon"
            };

            PromocaoBusiness promocaoBussiness = new PromocaoBusiness(itemRepo, pedidoRepo);


            //Act
            promocaoBussiness.promocaoCarne(new List<FecharPedidoModel>() { hamburger });

            //Assert
            Assert.Equal(hamburger.valorDesconto, 9);
        }

        [Fact]
        public void TestaRegraPromocaoQueijo()
        {
            //Arrange
            PedidoRepository pedidoRepo = new PedidoRepository();
            ItemPedidoRepository itemRepo = new ItemPedidoRepository();

            FecharPedidoModel queijo = new FecharPedidoModel()
            {
                idItemPedido = 10,
                idPedido = 4,
                idLanche = 2,
                idIngrediente = 6,
                idItemPedidoIngrediente = 1,
                valor = 1.50,
                quantidade = 10,
                nomeLanche = "X-Bacon"
            };

            PromocaoBusiness promocaoBussiness = new PromocaoBusiness(itemRepo, pedidoRepo);


            //Act
            promocaoBussiness.promocaoQueijo(new List<FecharPedidoModel>() { queijo });

            //Assert
            Assert.Equal(queijo.valorDesconto, 4.50);
        }
    }
}
