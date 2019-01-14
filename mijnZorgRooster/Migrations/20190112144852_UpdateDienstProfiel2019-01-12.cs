using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class UpdateDienstProfiel20190112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DienstProfiel_Dienst_DienstID",
                table: "DienstProfiel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DienstProfiel",
                table: "DienstProfiel");

            migrationBuilder.DropColumn(
                name: "DienstID",
                table: "DienstProfiel");

            migrationBuilder.AddColumn<int>(
                name: "DienstProfielID",
                table: "DienstProfiel",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DienstDataDienstProfielID",
                table: "Dienst",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DienstProfiel",
                table: "DienstProfiel",
                column: "DienstProfielID");

            migrationBuilder.CreateIndex(
                name: "IX_Dienst_DienstDataDienstProfielID",
                table: "Dienst",
                column: "DienstDataDienstProfielID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dienst_DienstProfiel_DienstDataDienstProfielID",
                table: "Dienst",
                column: "DienstDataDienstProfielID",
                principalTable: "DienstProfiel",
                principalColumn: "DienstProfielID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dienst_DienstProfiel_DienstDataDienstProfielID",
                table: "Dienst");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DienstProfiel",
                table: "DienstProfiel");

            migrationBuilder.DropIndex(
                name: "IX_Dienst_DienstDataDienstProfielID",
                table: "Dienst");

            migrationBuilder.DropColumn(
                name: "DienstProfielID",
                table: "DienstProfiel");

            migrationBuilder.DropColumn(
                name: "DienstDataDienstProfielID",
                table: "Dienst");

            migrationBuilder.AddColumn<int>(
                name: "DienstID",
                table: "DienstProfiel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DienstProfiel",
                table: "DienstProfiel",
                column: "DienstID");

            migrationBuilder.AddForeignKey(
                name: "FK_DienstProfiel_Dienst_DienstID",
                table: "DienstProfiel",
                column: "DienstID",
                principalTable: "Dienst",
                principalColumn: "DienstID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
