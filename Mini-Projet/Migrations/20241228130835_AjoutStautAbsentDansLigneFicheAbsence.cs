using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class AjoutStautAbsentDansLigneFicheAbsence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatutAbsent",
                table: "ligneFicheAbsences",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatutAbsent",
                table: "ligneFicheAbsences");
        }
    }
}
