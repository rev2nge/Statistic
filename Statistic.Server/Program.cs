using Microsoft.EntityFrameworkCore;
using Statistic.Application.Interfaces;
using Statistic.Infrastructure.Context;
using Statistic.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<StatisticContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Statistic.Infrastructure")));

services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IMeteorologyRepository, MeteorologyRepository>();
services.AddScoped<ISourceRepository, SourceRepository>();
services.AddScoped<IContactRepository, ContactRepository>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

//app.MapFallbackToFile("/index.html");

app.Run();
