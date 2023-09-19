using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : Controller
    {
        private Principal administrador = new Principal();
        private Resultado resultado = new Resultado();
        private ResultadoString resultadoString = new ResultadoString();
        private ResultadoClase<Suscripcion> resultadoClase = new ResultadoClase<Suscripcion>();
        public PrincipalController()
        {
            administrador = new Principal();
            resultado = new Resultado();
            resultadoString = new ResultadoString();
            resultadoClase = new ResultadoClase<Suscripcion>();
        }
        [HttpPost("AñadirSuscripcion")]
        public IActionResult DarDeAltaSuscripcion([FromBody] RequestAñadirSuscripcion request)
        {
            resultado = administrador.AñadirSuscripcion(request);
            if (resultado.Success ==true)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado.Message);
            }
        }
        [HttpGet("DevolverListadoSuscripciones")]
        public IActionResult DevolverListaSuscripciones([FromQuery]RequestDevolverListadoSuscripciones request)
        {
            List<Suscripcion> lista = administrador.DevolverListadoSuscripciones(request);
            if (lista==null)
            {
                return Ok("La lista esta vacia");
            }
            else
            {
                return Ok(lista);
            }
        }
        [HttpGet("ConsultarId")]
        public IActionResult DevolverSuscripcion([FromQuery]int id)
        {
            resultadoString = administrador.DevolverDescripcionSuscripcion(id);
            if (resultadoString.Success==false)
            {
                return NotFound(resultadoString.Message);
            }
            else
            {
                return Ok(resultadoString.Descripcion);
            }
        }

        [HttpPut("ActualizarMonto")]
        public IActionResult ActualizarMontoSuscripcion([FromBody]RequestActualizarMontoBaseSuscripcion request)
        {
            resultado = administrador.ActualizarMontoBaseSuscripcion(request);
            if (resultado.Success)
            {
                return Ok(resultado.Message);
            }
            else
            {
                return NotFound(resultado.Message);
            }
        }
        [HttpPut("EliminarSuscripcion")]
        public IActionResult EliminarSuscripcion([FromQuery]int id)
        {
            resultado = administrador.EliminarSuscripcion(id);
            if (resultado.Success)
            {
                return Ok(resultado.Message);
            }
            else
            {
                return NotFound(resultado.Message);
            }
        }

    }
}
