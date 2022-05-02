using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawOffice05.Migrations
{
    public partial class AllTablesAtOnceSiniorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfLaw = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InfoAboutLaw = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProblemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProblemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UrgencyType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TypeOfAnswer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    StatusOfTheOrder = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seniors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seniors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsideCaseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InsideCaseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientFirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientMiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientFamiliName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientAdrress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SeniorId = table.Column<int>(type: "int", nullable: false),
                    CaseDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Seniors_SeniorId",
                        column: x => x.SeniorId,
                        principalTable: "Seniors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfInstance = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CaseNumberByTheInstance = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CaseNumberDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instances_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsideDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfTheDocument = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfCreating = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyOutGoingNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RecipientЕntranceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TheDocumentInfo = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    TheDocument = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsideDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsideDocuments_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutsideDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfTheDocument = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OriginalNumberOfTheDocument = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OriginalDateOfTheDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheDocumentInfo = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    TheDocument = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutsideDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutsideDocuments_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_SeniorId",
                table: "Cases",
                column: "SeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_InsideDocuments_InstanceId",
                table: "InsideDocuments",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_CaseId",
                table: "Instances",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OutsideDocuments_InstanceId",
                table: "OutsideDocuments",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seniors_UserId",
                table: "Seniors",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfos");

            migrationBuilder.DropTable(
                name: "InsideDocuments");

            migrationBuilder.DropTable(
                name: "OrderProblemTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OutsideDocuments");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Seniors");
        }
    }
}
