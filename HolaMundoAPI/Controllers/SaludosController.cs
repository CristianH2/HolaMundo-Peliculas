using HolaMundoAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaludosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Saludar([FromBody] MensajeDto mensaje)
        {
            IdDto id = new IdDto{Fecha = DateTime.Now, Saludo = mensaje.Saludo};
            return Ok(id);
        }

        [HttpDelete]
        public IActionResult HacerError()
        {
            ProblemDetails problemDetails;
            problemDetails = new ProblemDetails
            {
                Status = 500,
                Detail = "Se ha producido un error inesperado en el servidor."
            };
            return StatusCode(500,problemDetails);
        }
    }
}
