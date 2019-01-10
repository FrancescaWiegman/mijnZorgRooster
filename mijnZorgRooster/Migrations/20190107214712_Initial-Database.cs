using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    MedewerkerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Tussenvoegsels = table.Column<string>(nullable: true),
                    Telefoonnummer = table.Column<string>(nullable: true),
                    MobielNummer = table.Column<string>(nullable: true),
                    Emailadres = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Woonplaats = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.MedewerkerID);
                });

            migrationBuilder.CreateTable(
                name: "Certificaat",
                columns: table => new
                {
                    CertificaatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedewerkerID = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    geldigTot = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificaat", x => x.CertificaatID);
                    table.ForeignKey(
                        name: "FK_Certificaat_Medewerker_MedewerkerID",
                        column: x => x.MedewerkerID,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
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
                    table.PrimaryKey("PK_Contract", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_Contract_Medewerker_MedewerkerID",
                        column: x => x.MedewerkerID,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RollID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    MedewerkerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RollID);
                    table.ForeignKey(
                        name: "FK_Rol_Medewerker_MedewerkerID",
                        column: x => x.MedewerkerID,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificaat_MedewerkerID",
                table: "Certificaat",
                column: "MedewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_MedewerkerID",
                table: "Contract",
                column: "MedewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_MedewerkerID",
                table: "Rol",
                column: "MedewerkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificaat");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Medewerker");
        }
    }
}
