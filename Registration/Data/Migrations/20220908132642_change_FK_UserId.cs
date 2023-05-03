using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class change_FK_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameApplicationUser_AspNetUsers_ApplicationUserId",
                table: "GameApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_GameApplicationUser_ApplicationUserId",
                table: "GameApplicationUser");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "GameApplicationUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GameApplicationUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_GameApplicationUser_UserId",
                table: "GameApplicationUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameApplicationUser_AspNetUsers_UserId",
                table: "GameApplicationUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameApplicationUser_AspNetUsers_UserId",
                table: "GameApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_GameApplicationUser_UserId",
                table: "GameApplicationUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GameApplicationUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "GameApplicationUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameApplicationUser_ApplicationUserId",
                table: "GameApplicationUser",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameApplicationUser_AspNetUsers_ApplicationUserId",
                table: "GameApplicationUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
