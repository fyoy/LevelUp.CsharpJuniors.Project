namespace FedorStore.UI.Models
{
    public record ProductItem(Guid Id,string Name, Guid CategoryId, string? Description);
}
