
using Microservicios_Amezquita.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios_Amezquita.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }
             
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Producto> Productos => Set<Producto>();

    
    }

}