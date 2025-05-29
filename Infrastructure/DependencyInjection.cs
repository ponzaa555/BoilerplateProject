using InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace InfraStructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            return services;
        }
        private static IServiceCollection AddDatabaseContext(this IServiceCollection services , IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
             services.AddDbContext<AppDbContext>( options => 
                {
                     Console.WriteLine("🔧 Configuring AppDbContext...");
                     options.UseMySql(connectionString, serverVersion)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors();
                }
            );
            return services;   
            // This method is intentionally left empty as a placeholder for future DbContext configuration.
        }
        /*
        Test connection to MySQL database at startup
        private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
           var connectionString = configuration.GetConnectionString("DefaultConnection");
           var serverVersion = ServerVersion.AutoDetect(connectionString);
           // check db Connection
           try
           {
            Console.WriteLine("SQL Version: " + serverVersion);
            using (var connect = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connect.Open();
                var testVersion = connect.ServerVersion;
                Console.WriteLine("✅ Connected to DB at startup " + testVersion);
                string query = "SHOW TABLES";
                using (var command = new MySqlCommand(query, connect))
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("📋 Tables in the database:");
                    while (reader.Read())
                    {
                        Console.WriteLine(" - " + reader.GetString(0));
                    }
                }
                connect.Close();
            }
            // Configure DbContext with MySQL 
            services.AddDbContext<AppDbContext>( options => 
                {
                     Console.WriteLine("🔧 Configuring AppDbContext...");
                     options.UseMySql(connectionString, serverVersion)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors();
                }
            );
           }catch (Exception ex)
           {
            Console.WriteLine("❌ Failed to connect to DB at startup");
            Console.WriteLine(ex.Message);
           }
            return services;
        }
        */
    }
}