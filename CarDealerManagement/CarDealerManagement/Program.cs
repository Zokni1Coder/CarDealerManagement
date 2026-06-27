using Entities;
using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using Entities.DTOs;
using Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CarsDBContext>(
    options => { options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionString")); }
    );
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
