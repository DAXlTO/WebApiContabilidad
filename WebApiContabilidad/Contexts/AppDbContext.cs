using Microsoft.EntityFrameworkCore;
using WebApiContabilidad.Entities;

namespace WebApiContabilidad.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Estado> estado { get; set; }
        public DbSet<TipoMovimiento> tipomovimiento { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Tienda> tienda { get; set; }
        public DbSet<Marca> marca { get; set; }
        public DbSet<Movimiento> movimiento { get; set; }

    }
}


