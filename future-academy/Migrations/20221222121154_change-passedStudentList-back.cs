using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace future_academy.Migrations
{
    public partial class changepassedStudentListback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Testid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Testid",
                table: "Students",
                column: "Testid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tests_Testid",
                table: "Students",
                column: "Testid",
                principalTable: "Tests",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tests_Testid",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Testid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Testid",
                table: "Students");
        }
    }
}
