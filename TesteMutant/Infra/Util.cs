using Microsoft.AspNetCore.Mvc;

namespace TesteMutant.Infra
{
    public class Util : ControllerBase
    {
        public IActionResult verificaStatus(string retorno)
        {
            if (retorno == "OK")
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest("Erro : " + retorno);
            }
        }
    }
}
