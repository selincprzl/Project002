using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project002.Repository.Migrations
{
    public partial class clothing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Horse",
                newName: "HorseName");

            migrationBuilder.CreateTable(
                name: "Clothing",
                columns: table => new
                {
                    ClothingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClothingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothing", x => x.ClothingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothing");

            migrationBuilder.RenameColumn(
                name: "HorseName",
                table: "Horse",
                newName: "Name");
        }
    }
}
