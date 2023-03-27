namespace FedorStore.Api.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAll();
        public Task Create(ProductEntity entity);
        public Task Update(ProductEntity entity);

        public Task Delete(Guid id);
        public Task<ProductEntity> GetById(Guid id);
    }
}
