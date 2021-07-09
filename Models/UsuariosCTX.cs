using Microsoft.EntityFrameworkCore;
namespace howarts1.Models
{
    public class UsuariosCTX:DbContext
    {
        public UsuariosCTX(DbContextOptions<UsuariosCTX> options):base (options)
        {
            


        }

        public DbSet<Usuario> Usuario {get; set;}
    }
}