using FedorStore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace FedorStore.Api.Service
{
    public sealed class ProductService : IProductService
    {
        private Dictionary<Guid, ProductItem> _products = new();
        public ProductService()
        {
            InitProducts();
        }
        public IEnumerable<ProductItem> GetProducts()
        {
            return _products.Values;
        }

        //Добавлен метод получения продукта по его guid
        public ProductItem? GetProductById(Guid guid)
        {
            try
            {
                var product = _products[guid];
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        private void InitProducts()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();

            _products = new Dictionary<Guid, ProductItem>
            {
                { Guid.Parse("12389865-095e-4d8b-b92f-c1591861ebe7"), new ProductItem(guid1, "Штаны" , "Чехословакия")},
                { Guid.Parse("c4ab5325-1399-4dae-bcc5-ad860c469b24"), new ProductItem(guid2, "Куртка", "КНДР")},
                { Guid.Parse("ada43051-6b36-4812-9bc1-b972585be3bc"), new ProductItem(guid3, "Сапоги", "Польша")}
            };
        }
    }
}
