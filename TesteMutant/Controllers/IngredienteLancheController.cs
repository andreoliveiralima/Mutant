using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteMutant.Infra;
using TesteMutant.Interfaces;
using TesteMutant.Model;

namespace TesteMutant.Controllers
{
    [Route("v1/ingredientelanche")]
    [ApiController]
    public class IngredienteLancheController : ControllerBase
    {
        private readonly IIngredienteLanche _IIngredienteLanche;

        public IngredienteLancheController(IIngredienteLanche IIngredienteLanche)
        {
            _IIngredienteLanche = IIngredienteLanche;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Inserir(IngredienteLancheModel ingredienteLanche)
        {
            try
            {
                return (new Util().verificaStatus(_IIngredienteLanche.Inserir(ingredienteLanche)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "IngredienteLanche.Inserir()", ex.Message));
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                return (new Util().verificaStatus(_IIngredienteLanche.Excluir(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "IngredienteLanche.Excluir()", ex.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                return Ok(_IIngredienteLanche.Buscar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "IngredienteLanche.Buscar()", ex.Message));
            }
        }
    }
}
