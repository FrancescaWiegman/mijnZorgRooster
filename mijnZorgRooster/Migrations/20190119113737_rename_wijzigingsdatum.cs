using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mijnZorgRooster.Migrations
{
    public partial class rename_wijzigingsdatum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LaatsteWijzigingsDatum",
                table: "Rooster",
                newName: "WijzigingsDatum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WijzigingsDatum",
                table: "Rooster",
                newName: "LaatsteWijzigingsDatum");
        }
    }
}
