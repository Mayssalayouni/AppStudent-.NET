using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class CodeLigne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences");

            migrationBuilder.AddColumn<int>(
                name: "CodeLigne",
                table: "ligneFicheAbsences",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences",
                column: "CodeLigne");

            migrationBuilder.CreateIndex(
                name: "IX_ligneFicheAbsences_CodeAbsence",
                table: "ligneFicheAbsences",
                column: "CodeAbsence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences");

            migrationBuilder.DropIndex(
                name: "IX_ligneFicheAbsences_CodeAbsence",
                table: "ligneFicheAbsences");

            migrationBuilder.DropColumn(
                name: "CodeLigne",
                table: "ligneFicheAbsences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences",
                column: "CodeAbsence");
        }
    }
}
