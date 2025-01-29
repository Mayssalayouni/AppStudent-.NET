using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class Two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeClasse = table.Column<int>(type: "int", nullable: false),
                    NumInscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClasseCodeClasse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.CodeEtudiant);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_ClasseCodeClasse",
                        column: x => x.ClasseCodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ligneFicheAbsences",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false),
                    FicheAbsenceCodeFicheAbsence = table.Column<int>(type: "int", nullable: false),
                    EtudiantCodeEtudiant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligneFicheAbsences", x => x.CodeFicheAbsence);
                    table.ForeignKey(
                        name: "FK_ligneFicheAbsences_Etudiants_EtudiantCodeEtudiant",
                        column: x => x.EtudiantCodeEtudiant,
                        principalTable: "Etudiants",
                        principalColumn: "CodeEtudiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ligneFicheAbsences_FichesAbsence_FicheAbsenceCodeFicheAbsence",
                        column: x => x.FicheAbsenceCodeFicheAbsence,
                        principalTable: "FichesAbsence",
                        principalColumn: "CodeFicheAbsence",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_ClasseCodeClasse",
                table: "Etudiants",
                column: "ClasseCodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_ligneFicheAbsences_EtudiantCodeEtudiant",
                table: "ligneFicheAbsences",
                column: "EtudiantCodeEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_ligneFicheAbsences_FicheAbsenceCodeFicheAbsence",
                table: "ligneFicheAbsences",
                column: "FicheAbsenceCodeFicheAbsence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ligneFicheAbsences");

            migrationBuilder.DropTable(
                name: "Etudiants");
        }
    }
}
