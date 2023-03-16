using Microsoft.EntityFrameworkCore;
using FedorStore.Api.DAL.Configurations;
using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<ProductEntity>? Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}
