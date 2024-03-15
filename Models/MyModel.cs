using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MyModel> MyEntities { get; set; }
    }

    public class MyModel
    {
        public string Proprietà1 { get; set; }
        public int Proprietà2 { get; set; }
        // Aggiungi altre proprietà se necessario
    }
}
