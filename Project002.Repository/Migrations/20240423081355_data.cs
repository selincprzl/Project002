using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmourId",
                table: "Samurai");

            migrationBuilder.DropColumn(
                name: "ClothingId",
                table: "Samurai");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Samurai");

            migrationBuilder.DropColumn(
                name: "WarId",
                table: "Samurai");

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Samurai",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Samurai",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SamuraiId",
                table: "Horse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArmourSamurai",
                columns: table => new
                {
                    ArmourId = table.Column<int>(type: "int", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmourSamurai", x => new { x.ArmourId, x.SamuraiId });
                    table.ForeignKey(
                        name: "FK_ArmourSamurai_Armour_ArmourId",
                        column: x => x.ArmourId,
                        principalTable: "Armour",
                        principalColumn: "ArmourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmourSamurai_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "SamuraiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothingSamurai",
                columns: table => new
                {
                    ClothingId = table.Column<int>(type: "int", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingSamurai", x => new { x.ClothingId, x.SamuraiId });
                    table.ForeignKey(
                        name: "FK_ClothingSamurai_Clothing_ClothingId",
                        column: x => x.ClothingId,
                        principalTable: "Clothing",
                        principalColumn: "ClothingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingSamurai_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "SamuraiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SamuraiWar",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(type: "int", nullable: false),
                    WarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiWar", x => new { x.SamuraiId, x.WarId });
                    table.ForeignKey(
                        name: "FK_SamuraiWar_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "SamuraiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiWar_War_WarId",
                        column: x => x.WarId,
                        principalTable: "War",
                        principalColumn: "WarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SamuraiWeapon",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiWeapon", x => new { x.SamuraiId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_SamuraiWeapon_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "SamuraiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiWeapon_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Samurai_ClanId",
                table: "Samurai",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Samurai_RankId",
                table: "Samurai",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Horse_SamuraiId",
                table: "Horse",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmourSamurai_SamuraiId",
                table: "ArmourSamurai",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingSamurai_SamuraiId",
                table: "ClothingSamurai",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiWar_WarId",
                table: "SamuraiWar",
                column: "WarId");

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiWeapon_WeaponId",
                table: "SamuraiWeapon",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_TimePeriodWar_WarId",
                table: "TimePeriodWar",
                column: "WarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horse_Samurai_SamuraiId",
                table: "Horse",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "SamuraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurai_Clan_ClanId",
                table: "Samurai",
                column: "ClanId",
                principalTable: "Clan",
                principalColumn: "ClanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurai_Rank_RankId",
                table: "Samurai",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "RankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horse_Samurai_SamuraiId",
                table: "Horse");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurai_Clan_ClanId",
                table: "Samurai");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurai_Rank_RankId",
                table: "Samurai");

            migrationBuilder.DropTable(
                name: "ArmourSamurai");

            migrationBuilder.DropTable(
                name: "ClothingSamurai");

            migrationBuilder.DropTable(
                name: "SamuraiWar");

            migrationBuilder.DropTable(
                name: "SamuraiWeapon");

            migrationBuilder.DropTable(
                name: "TimePeriodWar");

            migrationBuilder.DropIndex(
                name: "IX_Samurai_ClanId",
                table: "Samurai");

            migrationBuilder.DropIndex(
                name: "IX_Samurai_RankId",
                table: "Samurai");

            migrationBuilder.DropIndex(
                name: "IX_Horse_SamuraiId",
                table: "Horse");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Samurai");

            migrationBuilder.DropColumn(
                name: "SamuraiId",
                table: "Horse");

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmourId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClothingId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
