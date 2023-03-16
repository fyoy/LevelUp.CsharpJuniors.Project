using FedorStore.Api.DAL;
using FedorStore.Api.DAL.Entities;
using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public sealed class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var entities = await _usersRepository.GetAll();
            return entities.Select(e => new User(e.Id, e.Name, e.IsAdmin));
        }

        public async Task AddUser(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                IsAdmin = (bool)user.IsAdmin
            };

            await _usersRepository.Create(userEntity);
        }
    }
}
