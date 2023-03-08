namespace FedorStore.Api.Models
{
 public sealed record User(Guid id, string name, bool? isAdmin);
}
