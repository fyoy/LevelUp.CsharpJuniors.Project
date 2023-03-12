namespace FedorStore.Api.DAL.Entities
{
    public sealed record UserEntity
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public bool IsAdmin { get; init; } = false;
        public IEnumerable<UserPropertyValue> Properties { get; set; } = Enumerable.Empty<UserPropertyValue>();
    }
}
