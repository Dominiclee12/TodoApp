using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly("WebAPI")
    );
});
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

//builder.Services.AddTransient<ITodoUseCases, TodoUseCases>();
builder.Services.AddTransient<ITodoServices, TodoServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
                            builder => builder.WithOrigins("http://localhost:54039") // React app URL
                                              .AllowAnyHeader()
                                              .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
