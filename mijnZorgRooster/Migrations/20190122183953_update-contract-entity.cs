using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class updatecontractentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dienst_Rooster_RoosterID",
                table: "Dienst");

            migrationBuilder.DropColumn(
                name: "ParttimePercentage",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "VerlofDagenPerJaar",
                table: "Contract");

            migrationBuilder.AddForeignKey(
                name: "FK_Dienst_Rooster_RoosterID",
                table: "Dienst",
                column: "RoosterID",
                principalTable: "Rooster",
                principalColumn: "RoosterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dienst_Rooster_RoosterID",
                table: "Dienst");

            migrationBuilder.AddColumn<int>(
                name: "ParttimePercentage",
                table: "Contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerlofDagenPerJaar",
                table: "Contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Dienst_Rooster_RoosterID",
                table: "Dienst",
                column: "RoosterID",
                principalTable: "Rooster",
                principalColumn: "RoosterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
