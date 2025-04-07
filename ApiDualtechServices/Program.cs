using Microsoft.EntityFrameworkCore;
using ApiDualtechServices.Services;
using ApiDualtechServices.Models.DualtechDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    var connectionString = builder.Configuration.GetConnectionString("DualtechConection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<DualtechDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DualtechConection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
