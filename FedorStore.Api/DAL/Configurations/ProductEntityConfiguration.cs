namespace FedorStore.Api.DAL.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(300);

            builder.Property(e => e.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(e => e.CategoryId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.HasIndex(e => e.CategoryId);
        }
    }
}
