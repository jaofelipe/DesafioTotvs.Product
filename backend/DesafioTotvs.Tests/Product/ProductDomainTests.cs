using DesafioTotvs.Domain.Models;
using FluentAssertions;
using System;
using Xunit;

namespace DesafioTotvs.Tests;

public class ProductDomainTests
{
    [Fact]
    public void Should_Create_Product_With_Valid_Values()
    {
        var product = new Product("Notebook", "Potente", 3500m);

        product.Name.Should().Be("Notebook");
        product.Description.Should().Be("Potente");
        product.Price.Should().Be(3500m);
        product.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Empty()
    {
        Action act = static () => new Product("", "ABC", 10m);

        act.Should().Throw<ArgumentException>()
            .WithMessage("*Name is required*");
    }

    [Fact]
    public void Should_Update_Product_Successfully()
    {
        var product = new Product("Old", "Desc", 10m);

        product.Update("New", "Other", 50m);

        product.Name.Should().Be("New");
        product.Description.Should().Be("Other");
        product.Price.Should().Be(50m);
    }

    [Fact]
    public void Should_Throw_When_Updating_With_Invalid_Price()
    {
        var product = new Product("ABC", "Test", 20);

        Action act = () => product.Update("ABC", "Test", -1);

        act.Should().Throw<ArgumentException>()
            .WithMessage("*Price must be greater or equal to zero*");
    }
}
