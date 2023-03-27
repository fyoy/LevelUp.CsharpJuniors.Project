using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FedorStore.Api.DAL
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsDbContext _dbContext;

        public ProductsRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<ProductEntity>> GetAll()
        {
            return Task.FromResult<IEnumerable<ProductEntity>>(_dbContext.Products!.ToList());
        }

        public async Task Create(ProductEntity entity)
        {
            await _dbContext.Products!.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductEntity> GetById(Guid id)
        {
            var entity = await _dbContext.Products!
                .FirstOrDefaultAsync(e => e.Id == id);

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(ProductEntity product)
        {
            _dbContext.Products!.Update(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Products!
                .FirstOrDefaultAsync(e => e.Id == id);

            _dbContext.Products! 
                .Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
