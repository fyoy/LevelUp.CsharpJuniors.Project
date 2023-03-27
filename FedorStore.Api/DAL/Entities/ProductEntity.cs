namespace FedorStore.Api.DAL.Entities;

public sealed class ProductEntity
{
    public Guid Id { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }

    public decimal Price { get; set; }

    public IEnumerable<PropertyValue> Properties { get; set; } = Enumerable.Empty<PropertyValue>();
}