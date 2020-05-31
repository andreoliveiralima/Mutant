using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteMutant.Business;
using TesteMutant.Infra;
using TesteMutant.Interfaces;

namespace TesteMutant.Controllers
{
    [Route("v1/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedido _IPedido;
        private readonly IItemPedido _IItemPedido;

        public PedidoController(IPedido IPedido, IItemPedido IItemPedido)
        {
            _IPedido = IPedido;
            _IItemPedido = IItemPedido;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                return Ok(_IPedido.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Pedido.Buscar()", ex.Message));
            }
        }

        [HttpGet]
        [Route("pedidosabertos")]
        public IActionResult BuscarPedidoAberto()
        {
            try
            {
                return Ok(_IPedido.BuscarPedidoAberto());
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Pedido.BuscarPedidoAberto()", ex.Message));
            }
        }

        [HttpGet]
        [Route("abrirpedido")]
        public IActionResult Abrir()
        {
            try
            {
                return Ok(_IPedido.Abrir());
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Pedido.Abrir()", ex.Message));
            }
        }

        [HttpPut]
        [Route("fecharpedido/{id:int}")]
        public IActionResult Fechar(int id)
        {
            try
            {
                return (new Util().verificaStatus(_IPedido.Fechar(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Pedido.Fechar()", ex.Message));
            }
        }

        [HttpPost]
        [Route("aplicarpromocao/{id:int}")]
        public IActionResult AplicarPromocao(int id)
        {
            try
            {
                new PromocaoBusiness(_IItemPedido, _IPedido).AplicaPromocao(id);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Pedido.Abrir()", ex.Message));
            }
        }
    }
}
