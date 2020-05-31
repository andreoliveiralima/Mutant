using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TesteMutant.Infra;
using TesteMutant.Interfaces;
using TesteMutant.Model;

namespace TesteMutant.Controllers
{
    [Route("v1/ingrediente")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngrediente _IIngrediente;

        public IngredienteController(IIngrediente IIngrediente)
        {
            _IIngrediente = IIngrediente;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_IIngrediente.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Ingrediente.Listar()", ex.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                return Ok(_IIngrediente.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Ingrediente.Buscar()", ex.Message));
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Inserir(IngredienteModel ingrediente)
        {
            try
            {
                return (new Util().verificaStatus(_IIngrediente.Inserir(ingrediente)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Ingrediente.Inserir()", ex.Message));
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult Atualizar(IngredienteModel ingrediente)
        {
            try
            {
                return (new Util().verificaStatus(_IIngrediente.Atualizar(ingrediente)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Ingrediente.Atualizar()", ex.Message));
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                return (new Util().verificaStatus(_IIngrediente.Excluir(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "Ingrediente.Excluir()", ex.Message));
            }
        }
    }
}
