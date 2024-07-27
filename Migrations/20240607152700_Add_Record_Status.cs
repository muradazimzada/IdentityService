using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Migrations
{
    /// <inheritdoc />
    public partial class Add_Record_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "UserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "UserPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "UserPageAccesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Divisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "AppPages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "AppApiKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "UserPositions");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "UserPageAccesses");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "AppPages");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "AppApiKeys");
        }
    }
}
