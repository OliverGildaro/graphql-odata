using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options)
          : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
