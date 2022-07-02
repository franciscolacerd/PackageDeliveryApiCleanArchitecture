using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class deliveryattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryAttributes",
                schema: "dbo",
                columns: table => new
                {
                    DeliveryAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryAttributeENG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryAttributeES = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryAttributePT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAttributes", x => x.DeliveryAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_DeliveryAttributes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    DeliveryAttributeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_DeliveryAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_DeliveryAttributes_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalSchema: "dbo",
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_DeliveryAttributes_DeliveryAttributes_DeliveryAttributeId",
                        column: x => x.DeliveryAttributeId,
                        principalSchema: "dbo",
                        principalTable: "DeliveryAttributes",
                        principalColumn: "DeliveryAttributeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryAttributes_DeliveryAttributeId",
                schema: "dbo",
                table: "Delivery_DeliveryAttributes",
                column: "DeliveryAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryAttributes_DeliveryId",
                schema: "dbo",
                table: "Delivery_DeliveryAttributes",
                column: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery_DeliveryAttributes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DeliveryAttributes",
                schema: "dbo");
        }
    }
}
