using System.Collections.Generic;
using System.Threading.Tasks;
using sonataBackend.Models;

namespace sonataBackend.Repository
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> ObtenerUsuarios();
        Task<Usuario> ObtenerUsuarioPorCorreo(string correoElectronico);
        Task AgregarUsuario(Usuario usuario);
    }
}
