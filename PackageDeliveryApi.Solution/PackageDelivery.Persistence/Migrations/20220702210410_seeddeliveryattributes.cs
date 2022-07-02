using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PackageDelivery.Domain;
using PackageDelivery.Domain.SmartEnums;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class seeddeliveryattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = new PackageDeliveryDbContextFactory().CreateDbContext(null))
            {
                var strategy = context.Database.CreateExecutionStrategy();

                strategy.Execute(() =>
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.DeliveryAttributes.AddRange(
                        new List<DeliveryAttribute>() {
                            new DeliveryAttribute()
                            {
                                Id = DeliveryAttributes.Pod.Id,
                                DeliveryAttributeENG = "Pod",
                                DeliveryAttributeES = "Pod",
                                DeliveryAttributePT = "Pod"
                            },
                            new DeliveryAttribute()
                            {
                                Id = DeliveryAttributes.SameDay.Id,
                                DeliveryAttributeENG = "Same Day",
                                DeliveryAttributeES = "Mismo día",
                                DeliveryAttributePT = "Mesmo dia"
                            },
                            new DeliveryAttribute()
                            {
                                Id = DeliveryAttributes.CashOnDelivery.Id,
                                DeliveryAttributeENG = "Cash On Delivery",
                                DeliveryAttributeES = "Colección",
                                DeliveryAttributePT = "Cobrança"
                            }
                        });
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.DeliveryAttributes ON;");
                        context.SaveChanges();
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.DeliveryAttributes OFF");

                        transaction.Commit();
                    }
                });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}