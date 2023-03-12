using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public sealed class UsersRepository : IUsersRepository
    {
        private readonly UsersDbContext _dbContext;

        public UsersRepository(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            return Task.FromResult<IEnumerable<UserEntity>>(_dbContext.Users!.ToList());
        }

        public async Task Create(UserEntity entity)
        {
            await _dbContext.Users!.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
