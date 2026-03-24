using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeTopGreatAgain.Database.Migrations
{
    /// <inheritdoc />
    public partial class Groups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_SenseiId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SenseiId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SenseiId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    GroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupUser_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_GroupId",
                table: "GroupUser",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_RoleId",
                table: "GroupUser",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.AddColumn<string>(
                name: "SenseiId",
                table: "Groups",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SenseiId",
                table: "Groups",
                column: "SenseiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_SenseiId",
                table: "Groups",
                column: "SenseiId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
