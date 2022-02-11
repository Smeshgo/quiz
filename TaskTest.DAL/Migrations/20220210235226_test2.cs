using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTest.DAL.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestUser_Tests_TestsTestId",
                table: "TestUser");

            migrationBuilder.RenameColumn(
                name: "TestsTestId",
                table: "TestUser",
                newName: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestUser_Tests_TestId",
                table: "TestUser",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestUser_Tests_TestId",
                table: "TestUser");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "TestUser",
                newName: "TestsTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestUser_Tests_TestsTestId",
                table: "TestUser",
                column: "TestsTestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
