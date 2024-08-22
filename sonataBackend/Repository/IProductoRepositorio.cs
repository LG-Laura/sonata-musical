using System.Collections.Generic;
using System.Threading.Tasks;
using sonataBackend.Models;

namespace sonataBackend.Repository
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task AgregarProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}
