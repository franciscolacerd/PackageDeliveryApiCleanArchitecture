using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PackageDelivery.Persistence.Entities;
using System.Security.Claims;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class SeedEventTypes : Migration
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
                        context.EventTypes.AddRange(
                        new List<EventType>() {
                            new EventType()
                            {
                                Id = 1,
                                EventTypeENG = "Created delivery",
                                EventTypeES = "Entrega creada",
                                EventTypePT = "Entrega criada"
                            },
                            new EventType()
                            {
                                Id = 2,
                                EventTypeENG = "Pickedup by carrier",
                                EventTypeES = "Recogido por el transportista",
                                EventTypePT = "Apanhado por transportadora"
                            },
                            new EventType()
                            {
                                Id = 3,
                                EventTypeENG = "In transit",
                                EventTypeES = "En tránsito",
                                EventTypePT = "Em trânsito"
                            },
                            new EventType()
                            {
                                Id = 4,
                                EventTypeENG = "Delivered to receiver",
                                EventTypeES = "Entregado al receptor",
                                EventTypePT = "Entregue ao recetor"
                            },
                            new EventType()
                            {
                                Id = 5,
                                EventTypeENG = "Unable to make pickup",
                                EventTypeES = "No se puede hacer la recogida",
                                EventTypePT = "Incapaz de fazer a recolha"
                            },
                            new EventType()
                            {
                                Id = 6,
                                EventTypeENG = "Unable to make delivery",
                                EventTypeES = "No se puede realizar la entrega",
                                EventTypePT = "Incapaz de fazer a entrega"
                            },
                            new EventType()
                            {
                                Id = 7,
                                EventTypeENG = "Returned to sender",
                                EventTypeES = "Devuelto al remitente",
                                EventTypePT = "Devolvido ao remetente"
                            }
                        });
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.EventTypes ON;");
                        context.SaveChanges();
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.EventTypes OFF");

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