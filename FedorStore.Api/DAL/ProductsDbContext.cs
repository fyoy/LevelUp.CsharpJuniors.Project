using Microsoft.EntityFrameworkCore;
using FedorStore.Api.DAL.Configurations;
using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public class UsersDbContext : DbContext
    {
        public DbSet<UserEntity>? Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}
