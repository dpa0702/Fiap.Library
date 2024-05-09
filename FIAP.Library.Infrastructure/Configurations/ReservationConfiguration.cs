using FIAP.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Library.Infrastructure.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(u => u.bookId).HasColumnType("INT");
            builder.Property(u => u.customerId).HasColumnType("INT");
            builder.Property(u => u.status).HasColumnType("INT");
            builder.HasOne(b => b.books).WithOne().HasForeignKey<Book>(b => b.Id);
            builder.HasOne(c => c.customers).WithOne().HasForeignKey<Customer>(c => c.Id);
        }
    }
}
