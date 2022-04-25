using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawOffice05.Migrations
{
    public partial class CutConectionBetweenUserAndCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_AspNetUsers_UserId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_UserId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "ClientAdrress",
                table: "Cases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientFamiliName",
                table: "Cases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientFirstName",
                table: "Cases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientID",
                table: "Cases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientMiddleName",
                table: "Cases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientAdrress",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ClientFamiliName",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ClientFirstName",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ClientMiddleName",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_UserId",
                table: "Cases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_AspNetUsers_UserId",
                table: "Cases",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
