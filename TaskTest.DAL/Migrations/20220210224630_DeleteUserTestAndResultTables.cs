using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTest.DAL.Migrations
{
    public partial class DeleteUserTestAndResultTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "UserTests");

            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    UserTestSId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserTestsTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => new { x.UserTestSId, x.UserTestsTestId });
                    table.ForeignKey(
                        name: "FK_TestUser_AspNetUsers_UserTestSId",
                        column: x => x.UserTestSId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestUser_Tests_UserTestsTestId",
                        column: x => x.UserTestsTestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_UserTestsTestId",
                table: "TestUser",
                column: "UserTestsTestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    UserTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => x.UserTestId);
                    table.ForeignKey(
                        name: "FK_UserTests_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTests_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_UserTests_UserTestId",
                        column: x => x.UserTestId,
                        principalTable: "UserTests",
                        principalColumn: "UserTestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserTestId",
                table: "Results",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_TestsId",
                table: "UserTests",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_UsersId",
                table: "UserTests",
                column: "UsersId");
        }
    }
}
