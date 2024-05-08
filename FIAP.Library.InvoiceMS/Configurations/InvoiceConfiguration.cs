using FIAP.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Library.InvoiceMS.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedNever().UseIdentityColumn();
            builder.Property(i => i.CustomerId).HasColumnType("INT");
            builder.Property(i => i.Description).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(i => i.Quantity).HasColumnType("INT");
            builder.Property(i => i.Total).HasColumnType("DECIMAL(5,2)"); // 5 casas totais com 2 decimais (até 999,99)
            builder.Property(i => i.Status).HasColumnType("INT");
        }
    }
}
