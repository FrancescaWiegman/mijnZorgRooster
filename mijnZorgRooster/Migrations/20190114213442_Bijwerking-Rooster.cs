using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class BijwerkingRooster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DienstProfiel_Rooster_RoosterID",
                table: "DienstProfiel");

            migrationBuilder.DropIndex(
                name: "IX_DienstProfiel_RoosterID",
                table: "DienstProfiel");

            migrationBuilder.DropColumn(
                name: "RoosterID",
                table: "DienstProfiel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoosterID",
                table: "DienstProfiel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DienstProfiel_RoosterID",
                table: "DienstProfiel",
                column: "RoosterID");

            migrationBuilder.AddForeignKey(
                name: "FK_DienstProfiel_Rooster_RoosterID",
                table: "DienstProfiel",
                column: "RoosterID",
                principalTable: "Rooster",
                principalColumn: "RoosterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
