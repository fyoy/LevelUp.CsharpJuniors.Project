using FedorStore.WebUI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;

namespace FedorStore.WebUI.Services
{
    public sealed class ProductsServiceProxy : IProductsServiceProxy
    {
        private readonly HttpClient _client;

        private readonly Endpoints _endpoints;

        private readonly NavigationManager _navigationManager;

        public ProductsServiceProxy(HttpClient client, IOptions<Endpoints> endpoints, NavigationManager navigationManager)
        {
            _client = client;
            _endpoints = endpoints.Value;
            _navigationManager = navigationManager;
        }

        public async Task<IEnumerable<ProductItem>> GetAllProducts()
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.GetAllProducts}";
            var item = await MakeGet<IEnumerable<ProductItem>>(requestUri)
                       ?? Enumerable.Empty<ProductItem>();

            return item!;
        }

        public async Task<ProductItem> GetProductById(Guid id)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.GetProductById}";
            requestUri = string.Format(requestUri, id);
            var item = await MakeGet<ProductItem>(requestUri);

            return item!;
        }

        public async Task CreateProduct(ProductItem productItem)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.CreateProduct}";
            await _client.PostAsJsonAsync(requestUri, productItem);

            _navigationManager.NavigateTo("/products");
        }

        public async Task DeleteProduct (Guid id)
        {
            var requestUri = $"{_endpoints.BaseUrl}{_endpoints.DeleteProduct}";
            requestUri = string.Format(requestUri, id);
            await _client.DeleteAsync(requestUri);

            _navigationManager.NavigateTo("/products");
        }

        public async Task UpdateProduct(ProductItem productItem)
        {
            await _client.PutAsJsonAsync($"{_endpoints.BaseUrl}{_endpoints.UpdateProduct}", productItem);
        }

        private async Task<T?> MakeGet<T>(string requestUri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri)
            };

            using var response = await _client.SendAsync(request);
            var result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }
    }
}
