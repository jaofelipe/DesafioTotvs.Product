using DesafioTotvs.Application.DTOs;
using DesafioTotvs.Application.Services;
using DesafioTotvs.Domain.Interfaces.Repositories;
using DesafioTotvs.Domain.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTotvs.Tests;

public class ProductAppServiceTests
{
    private readonly Mock<IProductRepository> _repoMock;
    private readonly ProductAppService _app;

    public ProductAppServiceTests()
    {
        _repoMock = new Mock<IProductRepository>();
        _app = new ProductAppService(_repoMock.Object);
    }

    [Fact]
    public async Task Should_Return_All_Products()
    {
        _repoMock.Setup(r => r.GetAllAsync(default))
                 .ReturnsAsync(new List<Product>
                 {
                    new("A", "Desc", 10),
                    new("B", "Desc", 20)
                 });

        var result = await _app.GetAllAsync();

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task Should_Create_Product()
    {
        var dto = new ProductCreateUpdateDto
        {
            Name = "Notebook",
            Description = "Teste",
            Price = 3500m
        };

        var result = await _app.CreateAsync(dto);

        result.Name.Should().Be("Notebook");
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Product>(), default), Times.Once);
    }

    [Fact]
    public async Task Should_Return_Null_When_Product_Not_Found()
    {
        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), default))
                 .ReturnsAsync((Product?)null);

        var result = await _app.GetByIdAsync(Guid.NewGuid());

        result.Should().BeNull();
    }
}
