using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class hi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armour",
                columns: table => new
                {
                    ArmourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmourName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmourDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armour", x => x.ArmourId);
                });

            migrationBuilder.CreateTable(
                name: "FrontPage",
                columns: table => new
                {
                    FrontPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontPage", x => x.FrontPageId);
                });

            migrationBuilder.CreateTable(
                name: "Samurai",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SamuraiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurai", x => x.SamuraiId);
                });

            migrationBuilder.CreateTable(
                name: "War",
                columns: table => new
                {
                    WarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathCount = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_War", x => x.WarId);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponId);
                });

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
                name: "Clan",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamuraiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ClanId);
                    table.ForeignKey(
                        name: "FK_Clan_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "SamuraiId");
                });

            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    HorseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamuraiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.HorseId);
                    table.ForeignKey(
                        name: "FK_Horse_Samurai_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurai",
                        principalColumn: "SamuraiId");
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

            migrationBuilder.CreateIndex(
                name: "IX_ArmourSamurai_SamuraiId",
                table: "ArmourSamurai",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_SamuraiId",
                table: "Clan",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_Horse_SamuraiId",
                table: "Horse",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiWeapon_WeaponId",
                table: "SamuraiWeapon",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmourSamurai");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "FrontPage");

            migrationBuilder.DropTable(
                name: "Horse");

            migrationBuilder.DropTable(
                name: "SamuraiWeapon");

            migrationBuilder.DropTable(
                name: "War");

            migrationBuilder.DropTable(
                name: "Armour");

            migrationBuilder.DropTable(
                name: "Samurai");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
