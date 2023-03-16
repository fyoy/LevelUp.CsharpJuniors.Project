using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.Models;

public sealed record User(Guid Id, string Name,bool IsAdmin)
{
    public static User FromEntity(UserEntity entity)
    {
        return new User(entity.Id, entity.Name, (bool)entity.IsAdmin);
    }
}