using DesafioTotvs.Application.DTOs;

namespace DesafioTotvs.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ProductDto> CreateAsync(ProductCreateUpdateDto dto, CancellationToken cancellationToken = default);
        Task<ProductDto?> UpdateAsync(Guid id, ProductCreateUpdateDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
