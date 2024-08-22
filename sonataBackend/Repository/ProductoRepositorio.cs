using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sonataBackend.Data;
using sonataBackend.Models;

namespace sonataBackend.Repository
{
    public class ProductoRepositorio: IProductoRepositorio
    {
        private readonly SonataBackendContexto _contexto;

        public ProductoRepositorio(SonataBackendContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _contexto.Productos.ToListAsync();
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _contexto.Productos.FindAsync(id);
        }

        public async Task AgregarProducto(Producto producto)
        {
            _contexto.Productos.Add(producto);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarProducto(Producto producto)
        {
            _contexto.Entry(producto).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await _contexto.Productos.FindAsync(id);
            if (producto != null)
            {
                _contexto.Productos.Remove(producto);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
