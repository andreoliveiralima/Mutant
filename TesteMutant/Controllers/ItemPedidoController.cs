using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TesteMutant.Infra;
using TesteMutant.Interfaces;
using TesteMutant.Model;

namespace TesteMutant.Controllers
{
    [Route("v1/itempedido")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedido _IItemPedido;

        public ItemPedidoController(IItemPedido IItemPedido)
        {
            _IItemPedido = IItemPedido;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult BuscarPorPedido(int id)
        {
            try
            {
                return Ok(_IItemPedido.BuscarPorPedido(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "ItemPedido.Buscar()", ex.Message));
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Inserir(ItemPedidoModel itemPedido)
        {
            try
            {
                int _idItemPedido = 0;
                var retorno = _IItemPedido.Inserir(itemPedido);
                if (retorno.Count() > 0)
                {
                    foreach (var itemRetorno in retorno)
                    {
                        _idItemPedido = itemRetorno.idItemPedido;
                    }

                    foreach (var item in itemPedido.ingrediente)
                    {
                        if (item.quantidade > 0)
                        {
                            item.idItemPedido = _idItemPedido;
                            new Util().verificaStatus(_IItemPedido.InserirIngrediente(item));
                        }
                    }
                }

                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "ItemPedido.Inserir()", ex.Message));
            }
        }


    }
}
