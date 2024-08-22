using System.Collections.Generic;
using System.Threading.Tasks;
using sonataBackend.Models;
using sonataBackend.Repository;

namespace sonataBackend.Services
{
    public class ServicioProducto
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ServicioProducto(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return _productoRepositorio.ObtenerProductos();
        }

        public Task AgregarProducto(Producto producto)
        {
            return _productoRepositorio.AgregarProducto(producto);
        }

        public Task ActualizarProducto(Producto producto)
        {
            return _productoRepositorio.ActualizarProducto(producto);
        }

        public Task EliminarProducto(int id)
        {
            return _productoRepositorio.EliminarProducto(id);
        }
    }
}
