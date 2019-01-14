using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class InitialRooster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooster",
                columns: table => new
                {
                    RoosterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Jaar = table.Column<int>(nullable: false),
                    Maand = table.Column<int>(nullable: false),
                    AantalDagen = table.Column<int>(nullable: false),
                    AanmaakDatum = table.Column<DateTime>(nullable: false),
                    LaatsteWijzigingsDatum = table.Column<DateTime>(nullable: false),
                    IsGevalideerd = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooster", x => x.RoosterID);
                });

            migrationBuilder.CreateTable(
                name: "Dienst",
                columns: table => new
                {
                    DienstID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    RoosterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dienst", x => x.DienstID);
                    table.ForeignKey(
                        name: "FK_Dienst_Rooster_RoosterID",
                        column: x => x.RoosterID,
                        principalTable: "Rooster",
                        principalColumn: "RoosterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DienstProfiel",
                columns: table => new
                {
                    DienstID = table.Column<int>(nullable: false),
                    Begintijd = table.Column<TimeSpan>(nullable: false),
                    Eindtijd = table.Column<TimeSpan>(nullable: false),
                    MinimaleBezetting = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienstProfiel", x => x.DienstID);
                    table.ForeignKey(
                        name: "FK_DienstProfiel_Dienst_DienstID",
                        column: x => x.DienstID,
                        principalTable: "Dienst",
                        principalColumn: "DienstID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dienst_RoosterID",
                table: "Dienst",
                column: "RoosterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DienstProfiel");

            migrationBuilder.DropTable(
                name: "Dienst");

            migrationBuilder.DropTable(
                name: "Rooster");
        }
    }
}
