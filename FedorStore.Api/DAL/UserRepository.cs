using FedorStore.Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;

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
            return Task.FromResult<IEnumerable<UserEntity>>(_dbContext.Users!.ToList());
        }

        public Task<UserEntity> GetUserById(Guid guid)
        {
            return _dbContext.Users!
            .FirstOrDefaultAsync(e => e.Id.Equals(guid));
        }
    }
}
