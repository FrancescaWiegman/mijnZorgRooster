using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class fix_fks_and_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "verlofDagenPerJaar",
                table: "Contract",
                newName: "VerlofDagenPerJaar");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Rol",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Rol");

            migrationBuilder.RenameColumn(
                name: "VerlofDagenPerJaar",
                table: "Contract",
                newName: "verlofDagenPerJaar");
        }
    }
}
