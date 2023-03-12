using Microsoft.EntityFrameworkCore;
using FedorStore.Api.DAL.Entities;
using FedorStore.Api.DAL.Configurations;

namespace FedorStore.Api.DAL
{
    public sealed class UsersDbContext : DbContext
    {
        public DbSet<UserEntity>? Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}
