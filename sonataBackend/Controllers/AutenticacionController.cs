using Microsoft.AspNetCore.Mvc;
using sonataBackend.Services;
using sonataBackend.DTOs;
using sonataBackend.Models;

namespace sonataBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly ServicioAutenticacion _servicioAutenticacion;

        public AutenticacionController(ServicioAutenticacion servicioAutenticacion)
        {
            _servicioAutenticacion = servicioAutenticacion;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro(UsuarioDTO usuarioDto)
        {
            var resultado = await _servicioAutenticacion.Registrar(usuarioDto);
            if (resultado == null)
            {
                return BadRequest("Registro fallido.");
            }
            return Ok(resultado);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDTO usuarioDto)
        {
            var resultado = await _servicioAutenticacion.IniciarSesion(usuarioDto);
            if (resultado == null)
            {
                return Unauthorized();
            }
            return Ok(resultado);
        }
    }
}

