namespace FedorStore.Api.Models
{
    public sealed record User(Guid Id, string Name, bool? IsAdmin);
}
