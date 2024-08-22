using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sonataBackend.Data;
using sonataBackend.Models;

namespace sonataBackend.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SonataBackendContexto _contexto;

        public UsuarioRepositorio(SonataBackendContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return await _contexto.Usuarios.Include(u => u.Rol).ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorCorreo(string correoElectronico)
        {
            return await _contexto.Usuarios.SingleOrDefaultAsync(u => u.CorreoElectronico == correoElectronico);
        }

        public async Task AgregarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
        }
    }
}
