using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDelivery.Persistence.Migrations
{
    public partial class ApiLogsfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiLogConfigurations",
                schema: "dbo",
                table: "ApiLogConfigurations");

            migrationBuilder.RenameTable(
                name: "ApiLogConfigurations",
                schema: "dbo",
                newName: "ApiLogs",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiLogs",
                schema: "dbo",
                table: "ApiLogs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiLogs",
                schema: "dbo",
                table: "ApiLogs");

            migrationBuilder.RenameTable(
                name: "ApiLogs",
                schema: "dbo",
                newName: "ApiLogConfigurations",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiLogConfigurations",
                schema: "dbo",
                table: "ApiLogConfigurations",
                column: "Id");
        }
    }
}
