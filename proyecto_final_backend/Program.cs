using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proyecto_final_backend.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<proyecto_final_backendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proyecto_final_backendContext") ?? throw new InvalidOperationException("Connection string 'proyecto_final_backendContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// CORS: ajusta los orígenes según la URL real de tu frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000", // ejemplo React local
            "http://localhost:4200"  // ejemplo Angular local
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
