using System.Reflection;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repository
{
    public class AppDbContext : DbContext
    {
      public AppDbContext()
       {
         Console.WriteLine("🛠️ Add Migration");
       }
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
       {
         Console.WriteLine("🛠️ AppDbContext constructed");
       }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // For Migration 
            if(!optionsBuilder.IsConfigured)
            {
              string conStr = "server=localhost;user=root;password=Pon912545;database=Boilerplate";
               optionsBuilder.UseMySql(conStr, ServerVersion.AutoDetect(conStr));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
            (Assembly.GetExecutingAssembly());
        }
        public DbSet<User> Users { get; set; }
    }
}