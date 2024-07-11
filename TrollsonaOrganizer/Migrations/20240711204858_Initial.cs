using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrollsonaOrganizer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BloodCastes",
                columns: table => new
                {
                    BloodCasteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColorHex = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Division = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodCastes", x => x.BloodCasteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StrifeSpecibi",
                columns: table => new
                {
                    StrifeSpecibusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeaponKind = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrifeSpecibi", x => x.StrifeSpecibusId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trolls",
                columns: table => new
                {
                    TrollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sign = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BloodCasteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trolls", x => x.TrollId);
                    table.ForeignKey(
                        name: "FK_Trolls_BloodCastes_BloodCasteId",
                        column: x => x.BloodCasteId,
                        principalTable: "BloodCastes",
                        principalColumn: "BloodCasteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StrifePortfolios",
                columns: table => new
                {
                    StrifePortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrollId = table.Column<int>(type: "int", nullable: false),
                    StrifeSpecibusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrifePortfolios", x => x.StrifePortfolioId);
                    table.ForeignKey(
                        name: "FK_StrifePortfolios_StrifeSpecibi_StrifeSpecibusId",
                        column: x => x.StrifeSpecibusId,
                        principalTable: "StrifeSpecibi",
                        principalColumn: "StrifeSpecibusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrifePortfolios_Trolls_TrollId",
                        column: x => x.TrollId,
                        principalTable: "Trolls",
                        principalColumn: "TrollId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StrifePortfolios_StrifeSpecibusId",
                table: "StrifePortfolios",
                column: "StrifeSpecibusId");

            migrationBuilder.CreateIndex(
                name: "IX_StrifePortfolios_TrollId",
                table: "StrifePortfolios",
                column: "TrollId");

            migrationBuilder.CreateIndex(
                name: "IX_Trolls_BloodCasteId",
                table: "Trolls",
                column: "BloodCasteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrifePortfolios");

            migrationBuilder.DropTable(
                name: "StrifeSpecibi");

            migrationBuilder.DropTable(
                name: "Trolls");

            migrationBuilder.DropTable(
                name: "BloodCastes");
        }
    }
}
