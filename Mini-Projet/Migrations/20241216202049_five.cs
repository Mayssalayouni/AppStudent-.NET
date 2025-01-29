using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_Etudiants_EtudiantCodeEtudiant",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_Absence_Seances_SeanceCodeSeance",
                table: "Absence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absence",
                table: "Absence");

            migrationBuilder.RenameTable(
                name: "Absence",
                newName: "Absences");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_SeanceCodeSeance",
                table: "Absences",
                newName: "IX_Absences_SeanceCodeSeance");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_EtudiantCodeEtudiant",
                table: "Absences",
                newName: "IX_Absences_EtudiantCodeEtudiant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absences",
                table: "Absences",
                column: "CodeAbsence");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Etudiants_EtudiantCodeEtudiant",
                table: "Absences",
                column: "EtudiantCodeEtudiant",
                principalTable: "Etudiants",
                principalColumn: "CodeEtudiant",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Seances_SeanceCodeSeance",
                table: "Absences",
                column: "SeanceCodeSeance",
                principalTable: "Seances",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Etudiants_EtudiantCodeEtudiant",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Seances_SeanceCodeSeance",
                table: "Absences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absences",
                table: "Absences");

            migrationBuilder.RenameTable(
                name: "Absences",
                newName: "Absence");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_SeanceCodeSeance",
                table: "Absence",
                newName: "IX_Absence_SeanceCodeSeance");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_EtudiantCodeEtudiant",
                table: "Absence",
                newName: "IX_Absence_EtudiantCodeEtudiant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absence",
                table: "Absence",
                column: "CodeAbsence");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_Etudiants_EtudiantCodeEtudiant",
                table: "Absence",
                column: "EtudiantCodeEtudiant",
                principalTable: "Etudiants",
                principalColumn: "CodeEtudiant",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_Seances_SeanceCodeSeance",
                table: "Absence",
                column: "SeanceCodeSeance",
                principalTable: "Seances",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
