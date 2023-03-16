using FedorStore.Api.DAL;
using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var entities = await _userRepository.GetAllUsers();
            return entities.Select(e => new User(e.Id, e.Name, e.IsAdmin));
        }

        public async Task<User> GetUserById(Guid guid)
        {
            var entity = await _userRepository.GetUserById(guid);
            return  new User(entity.Id, entity.Name, entity.IsAdmin);
        }
    }
}
