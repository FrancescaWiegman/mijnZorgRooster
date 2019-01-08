using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class zorginstellin812019a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Rol");

            migrationBuilder.RenameColumn(
                name: "RolID",
                table: "Rol",
                newName: "RollID");

            migrationBuilder.CreateTable(
                name: "ContractDto",
                columns: table => new
                {
                    ContractID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginDatum = table.Column<DateTime>(nullable: false),
                    Einddatum = table.Column<DateTime>(nullable: false),
                    ContractUren = table.Column<int>(nullable: false),
                    MedewerkerID = table.Column<int>(nullable: true),
                    VerlofDagenPerJaar = table.Column<int>(nullable: false),
                    ParttimePercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDto", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_ContractDto_Medewerker_MedewerkerID",
                        column: x => x.MedewerkerID,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractDto_MedewerkerID",
                table: "ContractDto",
                column: "MedewerkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractDto");

            migrationBuilder.RenameColumn(
                name: "RollID",
                table: "Rol",
                newName: "RolID");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Rol",
                nullable: true);
        }
    }
}
