using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Etudiants_EtudiantCodeEtudiant",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Seances_SeanceCodeSeance",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Enseignants_Departements_DepartementCodeDepartement",
                table: "Enseignants");

            migrationBuilder.DropForeignKey(
                name: "FK_Enseignants_Grades_GradeCodeGrade",
                table: "Enseignants");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsenceSeances_FichesAbsence_FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsenceSeances_Seances_SeanceCodeSeance",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_ligneFicheAbsences_Etudiants_EtudiantCodeEtudiant",
                table: "ligneFicheAbsences");

            migrationBuilder.DropForeignKey(
                name: "FK_ligneFicheAbsences_FichesAbsence_FicheAbsenceCodeFicheAbsence",
                table: "ligneFicheAbsences");

            migrationBuilder.DropTable(
                name: "FichesAbsence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences");

            migrationBuilder.DropIndex(
                name: "IX_ligneFicheAbsences_EtudiantCodeEtudiant",
                table: "ligneFicheAbsences");

            migrationBuilder.DropIndex(
                name: "IX_ligneFicheAbsences_FicheAbsenceCodeFicheAbsence",
                table: "ligneFicheAbsences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FichesAbsenceSeances",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropIndex(
                name: "IX_FichesAbsenceSeances_FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropIndex(
                name: "IX_FichesAbsenceSeances_SeanceCodeSeance",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropIndex(
                name: "IX_Enseignants_DepartementCodeDepartement",
                table: "Enseignants");

            migrationBuilder.DropIndex(
                name: "IX_Enseignants_GradeCodeGrade",
                table: "Enseignants");

            migrationBuilder.DropColumn(
                name: "CodeFicheAbsence",
                table: "ligneFicheAbsences");

            migrationBuilder.DropColumn(
                name: "EtudiantCodeEtudiant",
                table: "ligneFicheAbsences");

            migrationBuilder.DropColumn(
                name: "CodeFicheAbsence",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropColumn(
                name: "FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropColumn(
                name: "DepartementCodeDepartement",
                table: "Enseignants");

            migrationBuilder.DropColumn(
                name: "GradeCodeGrade",
                table: "Enseignants");

            migrationBuilder.DropColumn(
                name: "AbsenceMarquee",
                table: "Absences");

            migrationBuilder.RenameColumn(
                name: "FicheAbsenceCodeFicheAbsence",
                table: "ligneFicheAbsences",
                newName: "CodeAbsence");

            migrationBuilder.RenameColumn(
                name: "SeanceCodeSeance",
                table: "FichesAbsenceSeances",
                newName: "CodeAbsence");

            migrationBuilder.RenameColumn(
                name: "EtudiantCodeEtudiant",
                table: "Absences",
                newName: "CodeMatiere");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Absences",
                newName: "DateJour");

            migrationBuilder.RenameColumn(
                name: "CodeSeance",
                table: "Absences",
                newName: "CodeEnseignant");

            migrationBuilder.RenameColumn(
                name: "CodeEtudiant",
                table: "Absences",
                newName: "CodeClasse");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_EtudiantCodeEtudiant",
                table: "Absences",
                newName: "IX_Absences_CodeMatiere");

            migrationBuilder.AlterColumn<int>(
                name: "SeanceCodeSeance",
                table: "Absences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClasseCodeClasse",
                table: "Absences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnseignantCodeEnseignant",
                table: "Absences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatiereCodeMatiere",
                table: "Absences",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences",
                column: "CodeAbsence");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FichesAbsenceSeances",
                table: "FichesAbsenceSeances",
                column: "CodeAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_ligneFicheAbsences_CodeEtudiant",
                table: "ligneFicheAbsences",
                column: "CodeEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_CodeSeance",
                table: "FichesAbsenceSeances",
                column: "CodeSeance");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_CodeDepartement",
                table: "Enseignants",
                column: "CodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_CodeGrade",
                table: "Enseignants",
                column: "CodeGrade");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_ClasseCodeClasse",
                table: "Absences",
                column: "ClasseCodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_CodeClasse",
                table: "Absences",
                column: "CodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_CodeEnseignant",
                table: "Absences",
                column: "CodeEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EnseignantCodeEnseignant",
                table: "Absences",
                column: "EnseignantCodeEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_MatiereCodeMatiere",
                table: "Absences",
                column: "MatiereCodeMatiere");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Classes_ClasseCodeClasse",
                table: "Absences",
                column: "ClasseCodeClasse",
                principalTable: "Classes",
                principalColumn: "CodeClasse");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Classes_CodeClasse",
                table: "Absences",
                column: "CodeClasse",
                principalTable: "Classes",
                principalColumn: "CodeClasse",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Enseignants_CodeEnseignant",
                table: "Absences",
                column: "CodeEnseignant",
                principalTable: "Enseignants",
                principalColumn: "CodeEnseignant",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Enseignants_EnseignantCodeEnseignant",
                table: "Absences",
                column: "EnseignantCodeEnseignant",
                principalTable: "Enseignants",
                principalColumn: "CodeEnseignant");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Matieres_CodeMatiere",
                table: "Absences",
                column: "CodeMatiere",
                principalTable: "Matieres",
                principalColumn: "CodeMatiere",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Matieres_MatiereCodeMatiere",
                table: "Absences",
                column: "MatiereCodeMatiere",
                principalTable: "Matieres",
                principalColumn: "CodeMatiere");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Seances_SeanceCodeSeance",
                table: "Absences",
                column: "SeanceCodeSeance",
                principalTable: "Seances",
                principalColumn: "CodeSeance");

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignants_Departements_CodeDepartement",
                table: "Enseignants",
                column: "CodeDepartement",
                principalTable: "Departements",
                principalColumn: "CodeDepartement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignants_Grades_CodeGrade",
                table: "Enseignants",
                column: "CodeGrade",
                principalTable: "Grades",
                principalColumn: "CodeGrade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsenceSeances_Absences_CodeAbsence",
                table: "FichesAbsenceSeances",
                column: "CodeAbsence",
                principalTable: "Absences",
                principalColumn: "CodeAbsence",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsenceSeances_Seances_CodeSeance",
                table: "FichesAbsenceSeances",
                column: "CodeSeance",
                principalTable: "Seances",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ligneFicheAbsences_Absences_CodeAbsence",
                table: "ligneFicheAbsences",
                column: "CodeAbsence",
                principalTable: "Absences",
                principalColumn: "CodeAbsence",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ligneFicheAbsences_Etudiants_CodeEtudiant",
                table: "ligneFicheAbsences",
                column: "CodeEtudiant",
                principalTable: "Etudiants",
                principalColumn: "CodeEtudiant",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Classes_ClasseCodeClasse",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Classes_CodeClasse",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Enseignants_CodeEnseignant",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Enseignants_EnseignantCodeEnseignant",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Matieres_CodeMatiere",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Matieres_MatiereCodeMatiere",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Seances_SeanceCodeSeance",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Enseignants_Departements_CodeDepartement",
                table: "Enseignants");

            migrationBuilder.DropForeignKey(
                name: "FK_Enseignants_Grades_CodeGrade",
                table: "Enseignants");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsenceSeances_Absences_CodeAbsence",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsenceSeances_Seances_CodeSeance",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_ligneFicheAbsences_Absences_CodeAbsence",
                table: "ligneFicheAbsences");

            migrationBuilder.DropForeignKey(
                name: "FK_ligneFicheAbsences_Etudiants_CodeEtudiant",
                table: "ligneFicheAbsences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences");

            migrationBuilder.DropIndex(
                name: "IX_ligneFicheAbsences_CodeEtudiant",
                table: "ligneFicheAbsences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FichesAbsenceSeances",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropIndex(
                name: "IX_FichesAbsenceSeances_CodeSeance",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropIndex(
                name: "IX_Enseignants_CodeDepartement",
                table: "Enseignants");

            migrationBuilder.DropIndex(
                name: "IX_Enseignants_CodeGrade",
                table: "Enseignants");

            migrationBuilder.DropIndex(
                name: "IX_Absences_ClasseCodeClasse",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_CodeClasse",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_CodeEnseignant",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_EnseignantCodeEnseignant",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_MatiereCodeMatiere",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "ClasseCodeClasse",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "EnseignantCodeEnseignant",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "MatiereCodeMatiere",
                table: "Absences");

            migrationBuilder.RenameColumn(
                name: "CodeAbsence",
                table: "ligneFicheAbsences",
                newName: "FicheAbsenceCodeFicheAbsence");

            migrationBuilder.RenameColumn(
                name: "CodeAbsence",
                table: "FichesAbsenceSeances",
                newName: "SeanceCodeSeance");

            migrationBuilder.RenameColumn(
                name: "DateJour",
                table: "Absences",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CodeMatiere",
                table: "Absences",
                newName: "EtudiantCodeEtudiant");

            migrationBuilder.RenameColumn(
                name: "CodeEnseignant",
                table: "Absences",
                newName: "CodeSeance");

            migrationBuilder.RenameColumn(
                name: "CodeClasse",
                table: "Absences",
                newName: "CodeEtudiant");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_CodeMatiere",
                table: "Absences",
                newName: "IX_Absences_EtudiantCodeEtudiant");

            migrationBuilder.AddColumn<int>(
                name: "CodeFicheAbsence",
                table: "ligneFicheAbsences",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EtudiantCodeEtudiant",
                table: "ligneFicheAbsences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodeFicheAbsence",
                table: "FichesAbsenceSeances",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartementCodeDepartement",
                table: "Enseignants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GradeCodeGrade",
                table: "Enseignants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SeanceCodeSeance",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AbsenceMarquee",
                table: "Absences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ligneFicheAbsences",
                table: "ligneFicheAbsences",
                column: "CodeFicheAbsence");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FichesAbsenceSeances",
                table: "FichesAbsenceSeances",
                column: "CodeFicheAbsence");

            migrationBuilder.CreateTable(
                name: "FichesAbsence",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeClasse = table.Column<int>(type: "int", nullable: false),
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false),
                    CodeMatiere = table.Column<int>(type: "int", nullable: false),
                    ClasseCodeClasse = table.Column<int>(type: "int", nullable: true),
                    DateJour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatiereCodeMatiere = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesAbsence", x => x.CodeFicheAbsence);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Classes_ClasseCodeClasse",
                        column: x => x.ClasseCodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse");
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Classes_CodeClasse",
                        column: x => x.CodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Enseignants_CodeEnseignant",
                        column: x => x.CodeEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "CodeEnseignant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Matieres_CodeMatiere",
                        column: x => x.CodeMatiere,
                        principalTable: "Matieres",
                        principalColumn: "CodeMatiere",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Matieres_MatiereCodeMatiere",
                        column: x => x.MatiereCodeMatiere,
                        principalTable: "Matieres",
                        principalColumn: "CodeMatiere");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ligneFicheAbsences_EtudiantCodeEtudiant",
                table: "ligneFicheAbsences",
                column: "EtudiantCodeEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_ligneFicheAbsences_FicheAbsenceCodeFicheAbsence",
                table: "ligneFicheAbsences",
                column: "FicheAbsenceCodeFicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances",
                column: "FicheAbsenceCodeFicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_SeanceCodeSeance",
                table: "FichesAbsenceSeances",
                column: "SeanceCodeSeance");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_DepartementCodeDepartement",
                table: "Enseignants",
                column: "DepartementCodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_GradeCodeGrade",
                table: "Enseignants",
                column: "GradeCodeGrade");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_ClasseCodeClasse",
                table: "FichesAbsence",
                column: "ClasseCodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_CodeClasse",
                table: "FichesAbsence",
                column: "CodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_CodeEnseignant",
                table: "FichesAbsence",
                column: "CodeEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_CodeMatiere",
                table: "FichesAbsence",
                column: "CodeMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_MatiereCodeMatiere",
                table: "FichesAbsence",
                column: "MatiereCodeMatiere");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignants_Departements_DepartementCodeDepartement",
                table: "Enseignants",
                column: "DepartementCodeDepartement",
                principalTable: "Departements",
                principalColumn: "CodeDepartement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignants_Grades_GradeCodeGrade",
                table: "Enseignants",
                column: "GradeCodeGrade",
                principalTable: "Grades",
                principalColumn: "CodeGrade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsenceSeances_FichesAbsence_FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances",
                column: "FicheAbsenceCodeFicheAbsence",
                principalTable: "FichesAbsence",
                principalColumn: "CodeFicheAbsence",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsenceSeances_Seances_SeanceCodeSeance",
                table: "FichesAbsenceSeances",
                column: "SeanceCodeSeance",
                principalTable: "Seances",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ligneFicheAbsences_Etudiants_EtudiantCodeEtudiant",
                table: "ligneFicheAbsences",
                column: "EtudiantCodeEtudiant",
                principalTable: "Etudiants",
                principalColumn: "CodeEtudiant",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ligneFicheAbsences_FichesAbsence_FicheAbsenceCodeFicheAbsence",
                table: "ligneFicheAbsences",
                column: "FicheAbsenceCodeFicheAbsence",
                principalTable: "FichesAbsence",
                principalColumn: "CodeFicheAbsence",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
