using DesafioTotvs.Domain.Models;
using DesafioTotvs.Infra.Contexts;
using DesafioTotvs.Infra.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTotvs.Tests;

public class ProductRepositoryTests
{
    private readonly AppDbContext _db;
    private readonly ProductRepository _repo;

    public ProductRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        _db = new AppDbContext(options);
        _repo = new ProductRepository(_db);
    }

    [Fact]
    public async Task Should_Add_Product()
    {
        var product = new Product("Mouse", "USB", 50);

        await _repo.AddAsync(product);

        var exists = await _db.Products.AnyAsync(p => p.Name == "Mouse");
        exists.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Get_Product_By_Id()
    {
        var product = new Product("Keyboard", "RGB", 200);
        await _repo.AddAsync(product);

        var loaded = await _repo.GetByIdAsync(product.Id);

        loaded.Should().NotBeNull();
        loaded!.Name.Should().Be("Keyboard");
    }
}
