using Microsoft.EntityFrameworkCore;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ExceptionLog> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("ExceptionLogs", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("ExceptionLogId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Exception)
                .IsRequired()
                .HasColumnName("Exception")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(t => t.CreatedDateUtc)
                .IsRequired()
                .HasColumnName("CreatedDateUtc")
                .HasColumnType("datetime2");

            #endregion Generated Configure
        }
    }
}