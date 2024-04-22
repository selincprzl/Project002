using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class clanwars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "War");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "War");

            migrationBuilder.CreateTable(
                name: "ClanWar",
                columns: table => new
                {
                    ClansClanId = table.Column<int>(type: "int", nullable: false),
                    WarsWarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanWar", x => new { x.ClansClanId, x.WarsWarId });
                    table.ForeignKey(
                        name: "FK_ClanWar_Clan_ClansClanId",
                        column: x => x.ClansClanId,
                        principalTable: "Clan",
                        principalColumn: "ClanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanWar_War_WarsWarId",
                        column: x => x.WarsWarId,
                        principalTable: "War",
                        principalColumn: "WarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanWar_WarsWarId",
                table: "ClanWar",
                column: "WarsWarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanWar");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "War",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                table: "War",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
