using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAll();
        Task AddUser(User user);
    }
}
