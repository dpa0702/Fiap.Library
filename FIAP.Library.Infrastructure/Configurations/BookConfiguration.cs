using FIAP.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Library.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(u => u.name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.author).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.genre).HasColumnType("INT");
        }
    }
}
