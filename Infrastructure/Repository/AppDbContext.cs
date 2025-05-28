using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repository
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
       {
         Console.WriteLine("🛠️ AppDbContext constructed");
       }
    }
}