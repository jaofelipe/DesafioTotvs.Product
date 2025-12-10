using DesafioTotvs.Application.DTOs;
using DesafioTotvs.Application.Interfaces;
using DesafioTotvs.Domain.Interfaces.Repositories;
using DesafioTotvs.Domain.Models;

namespace DesafioTotvs.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _productRepository;

    public ProductAppService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _productRepository.GetAllAsync(cancellationToken);

        return entities.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        });
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _productRepository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
            return null;

        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price
        };
    }

    public async Task<ProductDto> CreateAsync(ProductCreateUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var product = new Product(dto.Name, dto.Description, dto.Price);

        await _productRepository.AddAsync(product, cancellationToken);

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    public async Task<ProductDto?> UpdateAsync(Guid id, ProductCreateUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _productRepository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
            return null;

        entity.Update(dto.Name, dto.Description, dto.Price);

        await _productRepository.UpdateAsync(entity, cancellationToken);

        return new ProductDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price
        };
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _productRepository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
            return false;

        await _productRepository.DeleteAsync(entity, cancellationToken);
        return true;
    }
}
