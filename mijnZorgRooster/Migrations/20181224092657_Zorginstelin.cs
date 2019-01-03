using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class Zorginstelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Medewerker_medewerkerID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Medewerker_medewerkerID",
                table: "Roll");

            migrationBuilder.RenameColumn(
                name: "medewerkerID",
                table: "Roll",
                newName: "MedewerkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Rol_medewerkerID",
                table: "Roll",
                newName: "IX_Rol_MedewerkerID");

            migrationBuilder.RenameColumn(
                name: "medewerkerID",
                table: "Medewerker",
                newName: "MedewerkerID");

            migrationBuilder.RenameColumn(
                name: "medewerkerID",
                table: "Contract",
                newName: "MedewerkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_medewerkerID",
                table: "Contract",
                newName: "IX_Contract_MedewerkerID");

            migrationBuilder.AddColumn<int>(
                name: "leeftijdInJaren",
                table: "Medewerker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContractID1",
                table: "Contract",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractID1",
                table: "Contract",
                column: "ContractID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Contract_ContractID1",
                table: "Contract",
                column: "ContractID1",
                principalTable: "Contract",
                principalColumn: "ContractID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Medewerker_MedewerkerID",
                table: "Contract",
                column: "MedewerkerID",
                principalTable: "Medewerker",
                principalColumn: "MedewerkerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Medewerker_MedewerkerID",
                table: "Roll",
                column: "MedewerkerID",
                principalTable: "Medewerker",
                principalColumn: "MedewerkerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Contract_ContractID1",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Medewerker_MedewerkerID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Medewerker_MedewerkerID",
                table: "Roll");

            migrationBuilder.DropIndex(
                name: "IX_Contract_ContractID1",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "leeftijdInJaren",
                table: "Medewerker");

            migrationBuilder.DropColumn(
                name: "ContractID1",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "MedewerkerID",
                table: "Roll",
                newName: "medewerkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Rol_MedewerkerID",
                table: "Roll",
                newName: "IX_Rol_medewerkerID");

            migrationBuilder.RenameColumn(
                name: "MedewerkerID",
                table: "Medewerker",
                newName: "medewerkerID");

            migrationBuilder.RenameColumn(
                name: "MedewerkerID",
                table: "Contract",
                newName: "medewerkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_MedewerkerID",
                table: "Contract",
                newName: "IX_Contract_medewerkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Medewerker_medewerkerID",
                table: "Contract",
                column: "medewerkerID",
                principalTable: "Medewerker",
                principalColumn: "medewerkerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Medewerker_medewerkerID",
                table: "Roll",
                column: "medewerkerID",
                principalTable: "Medewerker",
                principalColumn: "medewerkerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
