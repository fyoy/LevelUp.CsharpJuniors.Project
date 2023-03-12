using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(300);

            builder.Property(e => e.IsAdmin)
                .IsRequired();
        }
    }
}
