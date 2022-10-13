using Microsoft.EntityFrameworkCore;

namespace Heepsiburada.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Marka> Marka { get; set; }

    }

}
