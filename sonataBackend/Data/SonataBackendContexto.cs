using Microsoft.EntityFrameworkCore;
using sonataBackend.Models;

namespace sonataBackend.Data
{
    public class SonataBackendContexto : DbContext
    {
        public SonataBackendContexto(DbContextOptions<SonataBackendContexto> opciones)
           : base(opciones)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modeloConstructor)
        {
            base.OnModelCreating(modeloConstructor);

            modeloConstructor.Entity<Rol>().HasData(
                new Rol { Id = 1, Descripcion = "Admin" },
                new Rol { Id = 2, Descripcion = "Usuario" }
            );
        }
    }
}
