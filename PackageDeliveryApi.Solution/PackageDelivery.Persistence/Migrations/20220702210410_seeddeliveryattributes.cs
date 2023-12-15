using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.SmartEnums;
using System.Security.Claims;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class seeddeliveryattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Migrations")
            };

            var identity = new ClaimsIdentity(claims, "MigrationsAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext
            {
                User = claimsPrincipal
            };

            using (var context = new PackageDeliveryDbContextFactory(new HttpContextAccessor { HttpContext = httpContext })
                .CreateDbContext(null))
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