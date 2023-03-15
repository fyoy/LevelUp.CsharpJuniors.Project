using Microsoft.EntityFrameworkCore;
using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL;

public sealed class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<ProductEntity>> GetAll()
    {
        return Task.FromResult<IEnumerable<ProductEntity>>((IEnumerable<ProductEntity>)_dbContext.Products!.ToList());
    }

    public Task<ProductEntity?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}