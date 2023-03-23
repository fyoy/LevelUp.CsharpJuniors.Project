namespace FedorStore.Api.Models;

public sealed record ProductItem(Guid Id, string Name, Guid CategoryId, string? Description,decimal Price)
{
    public static ProductItem FromEntity(ProductEntity entity)
    {
        return new ProductItem(entity.Id, entity.Name, entity.CategoryId, entity.Description, entity.Price);
    }
}