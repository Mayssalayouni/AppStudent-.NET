using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsenceSeances_Seance_SeanceCodeSeance",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seance",
                table: "Seance");

            migrationBuilder.RenameTable(
                name: "Seance",
                newName: "Seances");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seances",
                table: "Seances",
                column: "CodeSeance");

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    CodeAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false),
                    CodeSeance = table.Column<int>(type: "int", nullable: false),
                    AbsenceMarquee = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtudiantCodeEtudiant = table.Column<int>(type: "int", nullable: false),
                    SeanceCodeSeance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.CodeAbsence);
                    table.ForeignKey(
                        name: "FK_Absence_Etudiants_EtudiantCodeEtudiant",
                        column: x => x.EtudiantCodeEtudiant,
                        principalTable: "Etudiants",
                        principalColumn: "CodeEtudiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absence_Seances_SeanceCodeSeance",
                        column: x => x.SeanceCodeSeance,
                        principalTable: "Seances",
                        principalColumn: "CodeSeance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_EtudiantCodeEtudiant",
                table: "Absence",
                column: "EtudiantCodeEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_SeanceCodeSeance",
                table: "Absence",
                column: "SeanceCodeSeance");

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsenceSeances_Seances_SeanceCodeSeance",
                table: "FichesAbsenceSeances",
                column: "SeanceCodeSeance",
                principalTable: "Seances",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsenceSeances_Seances_SeanceCodeSeance",
                table: "FichesAbsenceSeances");

            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seances",
                table: "Seances");

            migrationBuilder.RenameTable(
                name: "Seances",
                newName: "Seance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seance",
                table: "Seance",
                column: "CodeSeance");

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsenceSeances_Seance_SeanceCodeSeance",
                table: "FichesAbsenceSeances",
                column: "SeanceCodeSeance",
                principalTable: "Seance",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
