
using Microsoft.EntityFrameworkCore;

namespace Microservicios_Amezquita.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       


    }

}