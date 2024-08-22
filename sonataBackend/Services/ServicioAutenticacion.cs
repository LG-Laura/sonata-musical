using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using sonataBackend.Models;
using sonataBackend.Repository;
using sonataBackend.DTOs;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace sonataBackend.Services
{
    public class ServicioAutenticacion
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly string _claveSecreta;

        public ServicioAutenticacion(IUsuarioRepositorio usuarioRepositorio, string claveSecreta)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _claveSecreta = claveSecreta;
        }

        public async Task<string> Registrar(UsuarioDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                CorreoElectronico = usuarioDto.CorreoElectronico,
                Contrasena = usuarioDto.Contrasena, // En producción, aplicar hash a la contraseña
                RolId = 2 // Rol de Usuario
            };

            await _usuarioRepositorio.AgregarUsuario(usuario);
            return GenerarToken(usuario);
        }

        public async Task<string> IniciarSesion(UsuarioDTO usuarioDto)
        {
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorCorreo(usuarioDto.CorreoElectronico);
            if (usuario == null || usuario.Contrasena != usuarioDto.Contrasena) // Verificar contraseña con hash en producción
            {
                return null;
            }

            return GenerarToken(usuario);
        }

        private string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.CorreoElectronico),
                new Claim(ClaimTypes.Role, usuario.Rol.Descripcion)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
