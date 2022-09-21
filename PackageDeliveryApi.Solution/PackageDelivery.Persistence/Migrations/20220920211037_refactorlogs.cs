using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class refactorlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "dbo",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "dbo",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateUtc",
                schema: "dbo",
                table: "ExceptionLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "dbo",
                table: "ApiLogConfigurations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "dbo",
                table: "ApiLogConfigurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateUtc",
                schema: "dbo",
                table: "ApiLogConfigurations",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "ExceptionLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "dbo",
                table: "ExceptionLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedDateUtc",
                schema: "dbo",
                table: "ExceptionLogs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "ApiLogConfigurations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "dbo",
                table: "ApiLogConfigurations");

            migrationBuilder.DropColumn(
                name: "UpdatedDateUtc",
                schema: "dbo",
                table: "ApiLogConfigurations");
        }
    }
}
