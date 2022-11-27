using future_academy.Models;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Contexts
{
    public class ServicesInfoContext : DbContext {
        public DbSet<ServicesInfo> ServicesInfo { get; set; } = null!;

        public ServicesInfoContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=pass;database=tp;", new MySqlServerVersion(new Version(8, 0, 31)));
        }
    }
}
