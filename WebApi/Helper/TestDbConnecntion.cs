using InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Helper
{
    public static class TestDbConnecntion
    {
        public static void PrintAllTableNames(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                try
                {
                    var connecttion = db.Database.GetDbConnection();
                    connecttion.Open();

                    using var command = connecttion.CreateCommand();
                    command.CommandText = "SHOW TABLES";

                    Console.WriteLine("📋 Tables in the database:");
                    using var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine(" - " + reader.GetString(0));
                    }
                    connecttion.Close();
                }catch(Exception ex)
                {
                    Console.WriteLine("❌ Error connecting to the database: " + ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}