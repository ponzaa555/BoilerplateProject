using Application;
using InfraStructure;
using InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi.Handler;
using WebApi.Helper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration)
            .AddControllers();
    // Register the global exception handler 
    // อ่านแบบไล่ลงนะ ไป ValidationExceptionHanler ละค่อยไป GlobalExceptionHandler ดังนั้นต้องใสากรณี true flase ไว้
    builder.Services.AddExceptionHandler<ValidationExceptionHanler>();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
}




var app = builder.Build();

// Test ConnectionDb with Pomelo
TestDbConnecntion.PrintAllTableNames(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseExceptionHandler("/");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
