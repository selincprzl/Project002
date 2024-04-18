using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class Emperor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emperor",
                columns: table => new
                {
                    EmperorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmourId = table.Column<int>(type: "int", nullable: false),
                    ClothingId = table.Column<int>(type: "int", nullable: false),
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    WarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emperor", x => x.EmperorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emperor");
        }
    }
}
