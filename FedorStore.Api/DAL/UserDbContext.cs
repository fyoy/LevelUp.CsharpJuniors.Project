using Microsoft.EntityFrameworkCore;
using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public sealed class UserDbContext : DbContext
    {
        public DbSet<UserEntity>? Users { get; set; }
    }
}
