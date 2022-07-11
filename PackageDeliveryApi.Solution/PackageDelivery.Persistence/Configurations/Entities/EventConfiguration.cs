using Microsoft.EntityFrameworkCore;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Event> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("Events", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("EventId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.DeliveryId)
                .IsRequired()
                .HasColumnName("DeliveryId")
                .HasColumnType("int");

            builder.Property(t => t.PackageId)
                .HasColumnName("VolumeId")
                .HasColumnType("int");

            builder.Property(t => t.EventTypeId)
                .IsRequired()
                .HasColumnName("EventTypeId")
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

            builder.HasOne(t => t.EventType)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("FK_Events_EventTypes_EventTypeId");

            builder.HasOne(t => t.Delivery)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK_Events_Deliveries_DeliveryId");

            builder.HasOne(t => t.Package)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_Events_Packages_PackageId");

            #endregion Generated Configure
        }
    }
}