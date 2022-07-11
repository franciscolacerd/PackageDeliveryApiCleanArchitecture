using Microsoft.EntityFrameworkCore;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EventType> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("EventTypes", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("EventTypeId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.EventTypeENG)
                .IsRequired()
                .HasColumnName("EventTypeENG")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.EventTypeES)
                .IsRequired()
                .HasColumnName("EventTypeES")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(t => t.EventTypePT)
                .IsRequired()
                .HasColumnName("EventTypePT")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

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

            #endregion Generated Configure
        }
    }
}