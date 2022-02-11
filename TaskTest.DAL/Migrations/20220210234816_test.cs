using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTest.DAL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
