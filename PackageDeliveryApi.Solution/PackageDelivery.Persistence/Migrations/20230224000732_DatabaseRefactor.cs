using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                schema: "dbo",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "PickingDate",
                schema: "dbo",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "PinNumber",
                schema: "dbo",
                table: "Deliveries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                schema: "dbo",
                table: "Deliveries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PickingDate",
                schema: "dbo",
                table: "Deliveries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PinNumber",
                schema: "dbo",
                table: "Deliveries",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }
    }
}
