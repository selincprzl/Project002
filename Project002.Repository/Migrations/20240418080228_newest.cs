using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class newest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emperor");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Horse",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "ArmourId",
                table: "Samurai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClanId",
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

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.RankId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropColumn(
                name: "ArmourId",
                table: "Samurai");

            migrationBuilder.DropColumn(
                name: "ClanId",
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

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Horse",
                newName: "Color");

            migrationBuilder.CreateTable(
                name: "Emperor",
                columns: table => new
                {
                    EmperorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmourId = table.Column<int>(type: "int", nullable: false),
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    ClothingId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    WarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emperor", x => x.EmperorId);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryId);
                });
        }
    }
}
