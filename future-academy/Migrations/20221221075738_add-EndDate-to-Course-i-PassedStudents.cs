using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace future_academy.Migrations
{
    public partial class addEndDatetoCourseiPassedStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Tests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "Tests",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Testid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "endDate",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Testid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "score",
                table: "Accounts");
        }
    }
}
