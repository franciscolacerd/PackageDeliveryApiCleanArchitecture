using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ////builder.ToTable("Users", "dbo");

            //// key
            //builder.HasKey(t => t.Id);

            //// properties
            //builder.Property(t => t.Id)
            //    .IsRequired()
            //    .HasColumnName("Id")
            //    .HasColumnType("int")
            //    .ValueGeneratedOnAdd();

            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.CreatedDateUtc)
                .IsRequired()
                .HasColumnName("CreatedDateUtc")
                .HasColumnType("datetime2");

            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.UpdatedDateUtc)
                .HasColumnName("UpdatedDateUtc")
                .HasColumnType("datetime2");
        }
    }
}