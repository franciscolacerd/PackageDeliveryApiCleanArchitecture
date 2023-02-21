using Microsoft.EntityFrameworkCore;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public partial class DeliveryDeliveryAttributeConfiguration : IEntityTypeConfiguration<DeliveryDeliveryAttribute>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryDeliveryAttribute> builder)
        {
            // table
            builder.ToTable("Delivery_DeliveryAttributes", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.DeliveryId)
                .IsRequired()
                .HasColumnName("DeliveryId")
                .HasColumnType("int");

            builder.Property(t => t.DeliveryAttributeId)
                .IsRequired()
                .HasColumnName("DeliveryAttributeId")
                .HasColumnType("int");

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

            // relationships
            builder.HasOne(t => t.DeliveryAttribute)
                .WithMany(t => t.DeliveryDeliveryAttributes)
                .HasForeignKey(d => d.DeliveryAttributeId)
                .HasConstraintName("FK_Deliveries_DeliveryAttributes_DeliveryAttributes_DeliveryAttributeId");

            builder.HasOne(t => t.Delivery)
                .WithMany(t => t.DeliveryDeliveryAttributes)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK_Deliveries_DeliveryAttributes_Deliveries_DeliveryId");
        }
    }
}