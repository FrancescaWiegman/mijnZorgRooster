using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class roosterwijziging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoosterDiensten");

            migrationBuilder.AlterColumn<string>(
                name: "Telefoonnummer",
                table: "Medewerker",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefoonnummer",
                table: "Medewerker",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

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
                name: "IX_RoosterDiensten_DienstId",
                table: "RoosterDiensten",
                column: "DienstId");
        }
    }
}
