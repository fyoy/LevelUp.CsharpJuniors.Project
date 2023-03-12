using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<UserEntity>> GetAll();
        public Task Create(UserEntity entity);
    }
}
