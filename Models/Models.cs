using Microsoft.EntityFrameworkCore;


namespace SimpleAPI.Models
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Slug { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; internal set; }
    }
}