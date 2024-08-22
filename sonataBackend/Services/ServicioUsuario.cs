using sonataBackend.Models;
using sonataBackend.Repository;

namespace sonataBackend.Services
{
    public class ServicioUsuario
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ServicioUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return _usuarioRepositorio.ObtenerUsuarios();
        }
    }
}
