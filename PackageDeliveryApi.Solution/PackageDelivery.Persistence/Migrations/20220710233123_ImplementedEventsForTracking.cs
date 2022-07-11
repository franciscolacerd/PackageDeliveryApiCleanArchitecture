using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class ImplementedEventsForTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                schema: "dbo",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeENG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventTypeES = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventTypePT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "dbo",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    VolumeId = table.Column<int>(type: "int", nullable: true),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalSchema: "dbo",
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalSchema: "dbo",
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Packages_PackageId",
                        column: x => x.VolumeId,
                        principalSchema: "dbo",
                        principalTable: "Packages",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_DeliveryId",
                schema: "dbo",
                table: "Events",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                schema: "dbo",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VolumeId",
                schema: "dbo",
                table: "Events",
                column: "VolumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EventTypes",
                schema: "dbo");
        }
    }
}
