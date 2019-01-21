using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class RoosterDienstProfiel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoosterDienstProfielen",
                columns: table => new
                {
                    DienstProfielId = table.Column<int>(nullable: false),
                    RoosterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoosterDienstProfielen", x => new { x.RoosterId, x.DienstProfielId });
                    table.ForeignKey(
                        name: "FK_RoosterDienstProfielen_DienstProfiel_DienstProfielId",
                        column: x => x.DienstProfielId,
                        principalTable: "DienstProfiel",
                        principalColumn: "DienstProfielID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoosterDienstProfielen_Rooster_RoosterId",
                        column: x => x.RoosterId,
                        principalTable: "Rooster",
                        principalColumn: "RoosterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoosterDienstProfielen_DienstProfielId",
                table: "RoosterDienstProfielen",
                column: "DienstProfielId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoosterDienstProfielen");
        }
    }
}
