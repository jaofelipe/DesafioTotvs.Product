using DesafioTotvs.Domain.Models;
using DesafioTotvs.Infra.Contexts;
using DesafioTotvs.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using DesafioTotvs.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application & Infra
builder.Services.AddServices();
builder.Services.AddInfrastructure(builder.Configuration);

// CORS para o frontend em localhost:4200
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Seed InMemory
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!await db.Products.AnyAsync())
    {
        db.Products.AddRange(
            new Product("Notebook", "Notebook básico", 3500m),
            new Product("Mouse", "Mouse sem fio", 80m)
        );
        await db.SaveChangesAsync();
    }
}

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

