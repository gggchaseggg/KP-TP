using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace future_academy.Migrations
{
    public partial class refactorNamePlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "patronomic",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Accounts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "patronomic",
                table: "Accounts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "Accounts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "patronomic",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Students",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "patronomic",
                table: "Students",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "Students",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
