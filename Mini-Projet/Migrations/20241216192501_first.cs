using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    CodeDepartement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepartement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.CodeDepartement);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    CodeGrade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGrade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.CodeGrade);
                });

            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    CodeGroupe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGroupe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.CodeGroupe);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    CodeMatiere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMatiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbreHeureCoursParSemaine = table.Column<int>(type: "int", nullable: false),
                    NbreHeureTDParSemaine = table.Column<int>(type: "int", nullable: false),
                    NbreHeureTPParSemaine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.CodeMatiere);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    CodeSeance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSeance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.CodeSeance);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRecrutement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDepartement = table.Column<int>(type: "int", nullable: false),
                    DepartementCodeDepartement = table.Column<int>(type: "int", nullable: false),
                    CodeGrade = table.Column<int>(type: "int", nullable: false),
                    GradeCodeGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.CodeEnseignant);
                    table.ForeignKey(
                        name: "FK_Enseignants_Departements_DepartementCodeDepartement",
                        column: x => x.DepartementCodeDepartement,
                        principalTable: "Departements",
                        principalColumn: "CodeDepartement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseignants_Grades_GradeCodeGrade",
                        column: x => x.GradeCodeGrade,
                        principalTable: "Grades",
                        principalColumn: "CodeGrade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    CodeClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeGroupe = table.Column<int>(type: "int", nullable: false),
                    CodeDepartement = table.Column<int>(type: "int", nullable: false),
                    GroupeCodeGroupe = table.Column<int>(type: "int", nullable: false),
                    DepartementCodeDepartement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.CodeClasse);
                    table.ForeignKey(
                        name: "FK_Classes_Departements_DepartementCodeDepartement",
                        column: x => x.DepartementCodeDepartement,
                        principalTable: "Departements",
                        principalColumn: "CodeDepartement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Groupe_GroupeCodeGroupe",
                        column: x => x.GroupeCodeGroupe,
                        principalTable: "Groupe",
                        principalColumn: "CodeGroupe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichesAbsence",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateJour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeMatiere = table.Column<int>(type: "int", nullable: false),
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false),
                    CodeClasse = table.Column<int>(type: "int", nullable: false),
                    MatiereCodeMatiere = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesAbsence", x => x.CodeFicheAbsence);
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

            migrationBuilder.CreateTable(
                name: "FichesAbsenceSeances",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeSeance = table.Column<int>(type: "int", nullable: false),
                    FicheAbsenceCodeFicheAbsence = table.Column<int>(type: "int", nullable: false),
                    SeanceCodeSeance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesAbsenceSeances", x => x.CodeFicheAbsence);
                    table.ForeignKey(
                        name: "FK_FichesAbsenceSeances_FichesAbsence_FicheAbsenceCodeFicheAbsence",
                        column: x => x.FicheAbsenceCodeFicheAbsence,
                        principalTable: "FichesAbsence",
                        principalColumn: "CodeFicheAbsence",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichesAbsenceSeances_Seance_SeanceCodeSeance",
                        column: x => x.SeanceCodeSeance,
                        principalTable: "Seance",
                        principalColumn: "CodeSeance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DepartementCodeDepartement",
                table: "Classes",
                column: "DepartementCodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GroupeCodeGroupe",
                table: "Classes",
                column: "GroupeCodeGroupe");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_DepartementCodeDepartement",
                table: "Enseignants",
                column: "DepartementCodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_GradeCodeGrade",
                table: "Enseignants",
                column: "GradeCodeGrade");

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

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_FicheAbsenceCodeFicheAbsence",
                table: "FichesAbsenceSeances",
                column: "FicheAbsenceCodeFicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_SeanceCodeSeance",
                table: "FichesAbsenceSeances",
                column: "SeanceCodeSeance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichesAbsenceSeances");

            migrationBuilder.DropTable(
                name: "FichesAbsence");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
