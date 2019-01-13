using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class addedmedewerkerroltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Medewerker_MedewerkerID",
                table: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Rol_MedewerkerID",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "MedewerkerID",
                table: "Rol");

            migrationBuilder.CreateTable(
                name: "MedewerkersRollen",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false),
                    MedewerkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkersRollen", x => new { x.MedewerkerId, x.RolId });
                    table.ForeignKey(
                        name: "FK_MedewerkersRollen_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkersRollen_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkersRollen_RolId",
                table: "MedewerkersRollen",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkersRollen");

            migrationBuilder.AddColumn<int>(
                name: "MedewerkerID",
                table: "Rol",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_MedewerkerID",
                table: "Rol",
                column: "MedewerkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Medewerker_MedewerkerID",
                table: "Rol",
                column: "MedewerkerID",
                principalTable: "Medewerker",
                principalColumn: "MedewerkerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
