namespace FedorStore.Api.DAL.Entities
{
    public sealed record UserEntity
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public bool isAdmin { get; init; } = false;

        public IEnumerable<PropertyValue> Properties { get; set; } = Enumerable.Empty<PropertyValue>();
    }
}
