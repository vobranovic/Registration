using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class isLoggedUserRegistered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LoggedUserRegistered",
                table: "Game",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoggedUserRegistered",
                table: "Game");
        }
    }
}
