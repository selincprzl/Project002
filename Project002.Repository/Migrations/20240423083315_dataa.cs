using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class dataa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "RankId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Horse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Horse_Samurai_SamuraiId",
                table: "Horse",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "SamuraiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurai_Clan_ClanId",
                table: "Samurai",
                column: "ClanId",
                principalTable: "Clan",
                principalColumn: "ClanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurai_Rank_RankId",
                table: "Samurai",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "RankId",
                table: "Samurai",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Samurai",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Horse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
