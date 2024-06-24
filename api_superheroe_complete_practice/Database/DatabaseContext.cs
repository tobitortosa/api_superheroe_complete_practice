using Microsoft.EntityFrameworkCore;

namespace api_superheroe_complete_practice.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { }

        public DbSet<Superheroe> Superheroes { get; set; }
    }
}
