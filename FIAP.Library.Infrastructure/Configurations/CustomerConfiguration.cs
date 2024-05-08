using FIAP.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Library.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever().UseIdentityColumn();
            builder.Property(c => c.Name).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(c => c.Phone).HasColumnType("VARCHAR(25)").IsRequired();
            builder.Property(c => c.Active).HasColumnType("bit").HasDefaultValue(1);
            builder.Property(c => c.email).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(c => c.address).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(c => c.status).HasColumnType("INT");
        }
    }
}
