using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PackageDelivery.Domain.Entities;
using PackageDelivery.Domain.SmartEnums;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class SeedEventTypes : Migration
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
                        context.EventTypes.AddRange(
                        new List<EventType>() {
                            new EventType()
                            {
                                Id = EventTypes.CreatedDelivery.Id,
                                EventTypeENG = "Created delivery",
                                EventTypeES = "Entrega creada",
                                EventTypePT = "Entrega criada"
                            },
                            new EventType()
                            {
                                Id = EventTypes.PickedupByCarrier.Id,
                                EventTypeENG = "Pickedup by carrier",
                                EventTypeES = "Recogido por el transportista",
                                EventTypePT = "Apanhado por transportadora"
                            },
                            new EventType()
                            {
                                Id = EventTypes.InTransit.Id,
                                EventTypeENG = "In transit",
                                EventTypeES = "En tránsito",
                                EventTypePT = "Em trânsito"
                            },
                            new EventType()
                            {
                                Id = EventTypes.DeliveredToReceiver.Id,
                                EventTypeENG = "Delivered to receiver",
                                EventTypeES = "Entregado al receptor",
                                EventTypePT = "Entregue ao recetor"
                            },
                            new EventType()
                            {
                                Id = EventTypes.UnableToMakePickup.Id,
                                EventTypeENG = "Unable to make pickup",
                                EventTypeES = "No se puede hacer la recogida",
                                EventTypePT = "Incapaz de fazer a recolha"
                            },
                            new EventType()
                            {
                                Id = EventTypes.UnableToMakeDelivery.Id,
                                EventTypeENG = "Unable to make delivery",
                                EventTypeES = "No se puede realizar la entrega",
                                EventTypePT = "Incapaz de fazer a entrega"
                            },
                            new EventType()
                            {
                                Id = EventTypes.ReturnedToSender.Id,
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