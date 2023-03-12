namespace FedorStore.Api.DAL.Entities
{
    public sealed record UserPropertyValue(Guid Id, Guid PropertyId, Guid UserId, string Value);
    public sealed record ProductPropertyValue(Guid Id, Guid PropertyId, Guid ProductId, string Value);
}
