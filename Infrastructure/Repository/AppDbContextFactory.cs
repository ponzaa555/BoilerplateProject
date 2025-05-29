// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// namespace InfraStructure.Repository
// {
//     public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
// {
//     public AppDbContext CreateDbContext(string[] args)
//     {
//         var connectionString = "server=localhost;user=root;password=Pon912545;database=Boilerplate";
//         var serverVersion = ServerVersion.AutoDetect(connectionString);

//         var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//         optionsBuilder.UseMySql(connectionString, serverVersion);

//         return new AppDbContext(optionsBuilder.Options);
//     }
// }

// }