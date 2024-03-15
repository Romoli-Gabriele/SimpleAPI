using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    Console.WriteLine($"Connection string: {connection}");
    options.UseSqlServer(connection);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure routing to handle requests
app.MapControllers();

// Avvia l'applicazione.
app.Run();