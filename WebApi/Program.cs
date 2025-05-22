using Application;
using InfraStructure;
using WebApi.Handler;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddControllers();
    // Register the global exception handler
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
}



var app = builder.Build();

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
