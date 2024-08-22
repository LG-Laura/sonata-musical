using Microsoft.AspNetCore.Mvc;
using sonataBackend.Services;

namespace sonataBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly ServicioUsuario _servicioUsuario;

        public UsuariosController(ServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _servicioUsuario.ObtenerUsuarios();
            return Ok(usuarios);
        }
    }
}
