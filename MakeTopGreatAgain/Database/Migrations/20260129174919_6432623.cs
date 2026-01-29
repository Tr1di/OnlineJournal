using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeTopGreatAgain.Database.Migrations
{
    /// <inheritdoc />
    public partial class _6432623 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectUser_AspNetUsers_UsersId",
                table: "SubjectUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "SubjectUser",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectUser_AspNetUsers_UserId",
                table: "SubjectUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectUser_AspNetUsers_UserId",
                table: "SubjectUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SubjectUser",
                newName: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectUser_AspNetUsers_UsersId",
                table: "SubjectUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
