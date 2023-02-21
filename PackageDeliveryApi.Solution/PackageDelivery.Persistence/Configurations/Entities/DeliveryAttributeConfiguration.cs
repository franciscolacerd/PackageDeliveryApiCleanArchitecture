using Microsoft.EntityFrameworkCore;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public partial class DeliveryAttributeConfiguration
        : IEntityTypeConfiguration<DeliveryAttribute>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryAttribute> builder)
        {
            // table
            builder.ToTable("DeliveryAttributes", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("DeliveryAttributeId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

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

            builder.Property(t => t.DeliveryAttributeENG)
                .IsRequired()
                .HasColumnName("DeliveryAttributeENG")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.DeliveryAttributeES)
                .IsRequired()
                .HasColumnName("DeliveryAttributeES")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.DeliveryAttributePT)
                .IsRequired()
                .HasColumnName("DeliveryAttributePT")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
        }
    }
}