using DesafioTotvs.Domain.Interfaces.Repositories;
using DesafioTotvs.Domain.Models;
using DesafioTotvs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DesafioTotvs.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbContext.Products.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
