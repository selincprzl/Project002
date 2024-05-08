using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class removasdsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurai_Rank_RankId",
                table: "Samurai");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "TimePeriodWar");

            migrationBuilder.DropTable(
                name: "TimePeriod");

            migrationBuilder.DropIndex(
                name: "IX_Samurai_RankId",
                table: "Samurai");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Samurai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Samurai",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.RankId);
                });

            migrationBuilder.CreateTable(
                name: "TimePeriod",
                columns: table => new
                {
                    TimePeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriod", x => x.TimePeriodId);
                });

            migrationBuilder.CreateTable(
                name: "TimePeriodWar",
                columns: table => new
                {
                    TimePeriodId = table.Column<int>(type: "int", nullable: false),
                    WarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriodWar", x => new { x.TimePeriodId, x.WarId });
                    table.ForeignKey(
                        name: "FK_TimePeriodWar_TimePeriod_TimePeriodId",
                        column: x => x.TimePeriodId,
                        principalTable: "TimePeriod",
                        principalColumn: "TimePeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimePeriodWar_War_WarId",
                        column: x => x.WarId,
                        principalTable: "War",
                        principalColumn: "WarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurai_RankId",
                table: "Samurai",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_TimePeriodWar_WarId",
                table: "TimePeriodWar",
                column: "WarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurai_Rank_RankId",
                table: "Samurai",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "RankId");
        }
    }
}
