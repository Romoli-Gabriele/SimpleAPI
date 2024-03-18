using Microsoft.EntityFrameworkCore;


namespace SimpleAPI.Models
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
{
    public DbSet<MyModel> MyModels { get; set; }
    // Aggiungi altre DbSet per le tue entità qui

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}

    public class MyModel
    {
        public int Id { get; set; }
        public string Proprietà1 { get; set; }
        public int Proprietà2 { get; set; }
        // Aggiungi altre proprietà se necessario
    }
}