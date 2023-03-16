using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserEntity>> GetAllUsers();
        public Task<UserEntity> GetUserById(Guid guid);
    }
}
