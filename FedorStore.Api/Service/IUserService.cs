using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid guid);
    }
}
