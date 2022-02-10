using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTest.DAL.Migrations
{
    public partial class rename_fkKey_userTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_AspNetUsers_UserId",
                table: "UserTests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_Tests_TestId",
                table: "UserTests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTests",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "UserTests",
                newName: "TestsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTests_UserId",
                table: "UserTests",
                newName: "IX_UserTests_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTests_TestId",
                table: "UserTests",
                newName: "IX_UserTests_TestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_AspNetUsers_UsersId",
                table: "UserTests",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_Tests_TestsId",
                table: "UserTests",
                column: "TestsId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_AspNetUsers_UsersId",
                table: "UserTests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_Tests_TestsId",
                table: "UserTests");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserTests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TestsId",
                table: "UserTests",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTests_UsersId",
                table: "UserTests",
                newName: "IX_UserTests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTests_TestsId",
                table: "UserTests",
                newName: "IX_UserTests_TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_AspNetUsers_UserId",
                table: "UserTests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_Tests_TestId",
                table: "UserTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
