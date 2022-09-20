using Microsoft.EntityFrameworkCore;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Configurations.Entities
{
    public class ApiLogConfiguration : IEntityTypeConfiguration<ApiLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApiLog> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("ApiLogConfigurations", "dbo");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Scheme)
                .HasColumnName("Scheme")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Host)
                .HasColumnName("Host")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.Path)
                .HasColumnName("Path")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.QueryString)
                .HasColumnName("QueryString")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.RequestBody)
                .HasColumnName("RequestBody")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.ResponseBody)
                .HasColumnName("ResponseBody")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.CreatedDateUtc)
                .IsRequired()
                .HasColumnName("CreatedDateUtc")
                .HasColumnType("datetime2");

            // relationships

            #endregion Generated Configure
        }
    }
}