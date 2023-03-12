namespace FedorStore.Api.DAL.Entities
{
    public sealed record ProductEntity
    {
        public Guid Id { get; init; }

        public Guid CategoryId { get; init; }

        public string Name { get; init; } = string.Empty;

        public string? Description { get; init; }

        public bool IsActive { get; init; }

        public IEnumerable<ProductPropertyValue> Properties { get; init; } = Enumerable.Empty<ProductPropertyValue>();
    }
}
