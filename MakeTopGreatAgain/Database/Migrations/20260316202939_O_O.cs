using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeTopGreatAgain.Database.Migrations
{
    /// <inheritdoc />
    public partial class O_O : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "GroupUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "GroupUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
