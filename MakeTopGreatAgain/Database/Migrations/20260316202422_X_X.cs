using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeTopGreatAgain.Database.Migrations
{
    /// <inheritdoc />
    public partial class X_X : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_AspNetRoles_RoleId",
                table: "GroupUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupUser_RoleId",
                table: "GroupUser");

            migrationBuilder.AddColumn<bool>(
                name: "IsSensei",
                table: "GroupUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserId_IsSensei",
                table: "GroupUser",
                columns: new[] { "UserId", "IsSensei" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroupUser_UserId_IsSensei",
                table: "GroupUser");

            migrationBuilder.DropColumn(
                name: "IsSensei",
                table: "GroupUser");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_RoleId",
                table: "GroupUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_AspNetRoles_RoleId",
                table: "GroupUser",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
