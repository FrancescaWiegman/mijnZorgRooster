using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class Medewerkersinroosteren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dienst_DienstProfiel_DienstDataDienstProfielID",
                table: "Dienst");

            migrationBuilder.RenameColumn(
                name: "DienstDataDienstProfielID",
                table: "Dienst",
                newName: "DienstProfielID");

            migrationBuilder.RenameIndex(
                name: "IX_Dienst_DienstDataDienstProfielID",
                table: "Dienst",
                newName: "IX_Dienst_DienstProfielID");

            migrationBuilder.AlterColumn<string>(
                name: "Emailadres",
                table: "Medewerker",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DienstID",
                table: "Medewerker",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoosterID",
                table: "DienstProfiel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_DienstID",
                table: "Medewerker",
                column: "DienstID");

            migrationBuilder.CreateIndex(
                name: "IX_DienstProfiel_RoosterID",
                table: "DienstProfiel",
                column: "RoosterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dienst_DienstProfiel_DienstProfielID",
                table: "Dienst",
                column: "DienstProfielID",
                principalTable: "DienstProfiel",
                principalColumn: "DienstProfielID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DienstProfiel_Rooster_RoosterID",
                table: "DienstProfiel",
                column: "RoosterID",
                principalTable: "Rooster",
                principalColumn: "RoosterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerker_Dienst_DienstID",
                table: "Medewerker",
                column: "DienstID",
                principalTable: "Dienst",
                principalColumn: "DienstID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dienst_DienstProfiel_DienstProfielID",
                table: "Dienst");

            migrationBuilder.DropForeignKey(
                name: "FK_DienstProfiel_Rooster_RoosterID",
                table: "DienstProfiel");

            migrationBuilder.DropForeignKey(
                name: "FK_Medewerker_Dienst_DienstID",
                table: "Medewerker");

            migrationBuilder.DropIndex(
                name: "IX_Medewerker_DienstID",
                table: "Medewerker");

            migrationBuilder.DropIndex(
                name: "IX_DienstProfiel_RoosterID",
                table: "DienstProfiel");

            migrationBuilder.DropColumn(
                name: "DienstID",
                table: "Medewerker");

            migrationBuilder.DropColumn(
                name: "RoosterID",
                table: "DienstProfiel");

            migrationBuilder.RenameColumn(
                name: "DienstProfielID",
                table: "Dienst",
                newName: "DienstDataDienstProfielID");

            migrationBuilder.RenameIndex(
                name: "IX_Dienst_DienstProfielID",
                table: "Dienst",
                newName: "IX_Dienst_DienstDataDienstProfielID");

            migrationBuilder.AlterColumn<string>(
                name: "Emailadres",
                table: "Medewerker",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddForeignKey(
                name: "FK_Dienst_DienstProfiel_DienstDataDienstProfielID",
                table: "Dienst",
                column: "DienstDataDienstProfielID",
                principalTable: "DienstProfiel",
                principalColumn: "DienstProfielID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
