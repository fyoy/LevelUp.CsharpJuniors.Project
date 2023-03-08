namespace FedorStore.Api.DAL.Entities
{
    public sealed record PropertyValue(Guid Id, Guid PropertyId, Guid UserId, string Value);
}
