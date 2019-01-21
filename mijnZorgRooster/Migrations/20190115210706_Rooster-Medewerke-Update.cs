using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class RoosterMedewerkeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedewerkerDiensten",
                columns: table => new
                {
                    MedewerkerId = table.Column<int>(nullable: false),
                    DienstId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerDiensten", x => new { x.MedewerkerId, x.DienstId });
                    table.ForeignKey(
                        name: "FK_MedewerkerDiensten_Dienst_DienstId",
                        column: x => x.DienstId,
                        principalTable: "Dienst",
                        principalColumn: "DienstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerDiensten_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoosterDiensten",
                columns: table => new
                {
                    RoosterId = table.Column<int>(nullable: false),
                    DienstId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoosterDiensten", x => new { x.RoosterId, x.DienstId });
                    table.ForeignKey(
                        name: "FK_RoosterDiensten_Dienst_DienstId",
                        column: x => x.DienstId,
                        principalTable: "Dienst",
                        principalColumn: "DienstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoosterDiensten_Rooster_RoosterId",
                        column: x => x.RoosterId,
                        principalTable: "Rooster",
                        principalColumn: "RoosterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerDiensten_DienstId",
                table: "MedewerkerDiensten",
                column: "DienstId");

            migrationBuilder.CreateIndex(
                name: "IX_RoosterDiensten_DienstId",
                table: "RoosterDiensten",
                column: "DienstId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerDiensten");

            migrationBuilder.DropTable(
                name: "RoosterDiensten");
        }
    }
}
