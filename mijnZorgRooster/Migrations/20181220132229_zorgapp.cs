using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class zorgapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    medewerkerID = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Medewerker", x => x.medewerkerID);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
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
                        principalColumn: "medewerkerID",
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
                    medewerkerID = table.Column<int>(nullable: true),
                    verlofDagenPerJaar = table.Column<int>(nullable: false),
                    ParttimePercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_Contract_Medewerker_medewerkerID",
                        column: x => x.medewerkerID,
                        principalTable: "Medewerker",
                        principalColumn: "medewerkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roll",
                columns: table => new
                {
                    RolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    medewerkerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                    table.ForeignKey(
                        name: "FK_Rol_Medewerker_medewerkerID",
                        column: x => x.medewerkerID,
                        principalTable: "Medewerker",
                        principalColumn: "medewerkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificaat_MedewerkerID",
                table: "Certificate",
                column: "MedewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_medewerkerID",
                table: "Contract",
                column: "medewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_medewerkerID",
                table: "Roll",
                column: "medewerkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Roll");

            migrationBuilder.DropTable(
                name: "Medewerker");
        }
    }
}
