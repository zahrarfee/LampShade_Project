using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class IgnoreName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Permissions");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
