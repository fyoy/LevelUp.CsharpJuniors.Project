namespace FedorStore.WebUI.Models
{
    public sealed record ProductItem(Guid Id,string Name, Guid CategoryId, string? Description);
}
