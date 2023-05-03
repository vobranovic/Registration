using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class numberOfPlayersRegistered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayersRegistered",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayersRegistered",
                table: "Game");
        }
    }
}
