using future_academy.Models;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Contexts
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }
        public DbSet<ServicesInfo> ServicesInfo { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
