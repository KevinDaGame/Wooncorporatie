using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Data.Migrations
{
    public partial class WoningDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Woning",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huisnummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Woning", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bewoner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bewoner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bewoner_Woning_WoningId",
                        column: x => x.WoningId,
                        principalTable: "Woning",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Woning",
                columns: new[] { "ID", "Huisnummer", "Naam" },
                values: new object[] { 2, 0, "zelftevree" });

            migrationBuilder.InsertData(
                table: "Woning",
                columns: new[] { "ID", "Huisnummer", "Naam" },
                values: new object[] { 3, 0, "boslust" });

            migrationBuilder.InsertData(
                table: "Bewoner",
                columns: new[] { "Id", "Naam", "WoningId" },
                values: new object[,]
                {
                    { 1, "Joosten", 2 },
                    { 2, "Verschoor", 2 },
                    { 3, "Rubens", 3 },
                    { 4, "Van Zanten", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bewoner_WoningId",
                table: "Bewoner",
                column: "WoningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bewoner");

            migrationBuilder.DropTable(
                name: "Woning");
        }
    }
}
