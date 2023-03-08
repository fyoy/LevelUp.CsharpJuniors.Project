using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return Task.FromResult(Enumerable.Empty<UserEntity>());
        }

        public Task<UserEntity> GetUserById()
        {
            throw new NotImplementedException();
        }
    }
}
