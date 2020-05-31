using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TesteMutant.Infra;
using TesteMutant.Interfaces;
using TesteMutant.Model;

namespace TesteMutant.Controllers
{
    [Route("v1/lanche")]
    [ApiController]
    public class LancheController : ControllerBase
    {
        private readonly ILanche _ILanche;

        public LancheController(ILanche ILanche)
        {
            _ILanche = ILanche;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ILanche.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Lanche.Listar()", ex.Message));
            }
        }

        [HttpGet]
        [Route("precos")]
        public IActionResult ListarPrecos()
        {
            try
            {
                return Ok(_ILanche.ListarPrecos());
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "LanchePrecos.Listar()", ex.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                return Ok(_ILanche.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Lanche.Buscar()", ex.Message));
            }
        }

        [HttpGet]
        [Route("buscaringredientes/{id:int}")]
        public IActionResult BuscarIngredientes(int id)
        {
            try
            {
                return Ok(_ILanche.BuscarIngredientes(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Lanche.Buscar()", ex.Message));
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Inserir(LancheModel lanche)
        {
            try
            {
                return (new Util().verificaStatus(_ILanche.Inserir(lanche)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Lanche.Inserir()", ex.Message));
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult Atualizar(LancheModel lanche)
        {
            try
            {
                return (new Util().verificaStatus(_ILanche.Atualizar(lanche)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Lanche.Atualizar()", ex.Message));
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                return (new Util().verificaStatus(_ILanche.Excluir(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "_ILanche.Excluir()", ex.Message));
            }
        }
    }
}
