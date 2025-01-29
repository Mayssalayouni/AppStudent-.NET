using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class Class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Departements_DepartementCodeDepartement",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_groupes_GroupeCodeGroupe",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_DepartementCodeDepartement",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_GroupeCodeGroupe",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "DepartementCodeDepartement",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "GroupeCodeGroupe",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ClasseCodeClasse",
                table: "FichesAbsence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_ClasseCodeClasse",
                table: "FichesAbsence",
                column: "ClasseCodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CodeDepartement",
                table: "Classes",
                column: "CodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CodeGroupe",
                table: "Classes",
                column: "CodeGroupe");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Departements_CodeDepartement",
                table: "Classes",
                column: "CodeDepartement",
                principalTable: "Departements",
                principalColumn: "CodeDepartement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_groupes_CodeGroupe",
                table: "Classes",
                column: "CodeGroupe",
                principalTable: "groupes",
                principalColumn: "CodeGroupe",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesAbsence_Classes_ClasseCodeClasse",
                table: "FichesAbsence",
                column: "ClasseCodeClasse",
                principalTable: "Classes",
                principalColumn: "CodeClasse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Departements_CodeDepartement",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_groupes_CodeGroupe",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesAbsence_Classes_ClasseCodeClasse",
                table: "FichesAbsence");

            migrationBuilder.DropIndex(
                name: "IX_FichesAbsence_ClasseCodeClasse",
                table: "FichesAbsence");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CodeDepartement",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CodeGroupe",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClasseCodeClasse",
                table: "FichesAbsence");

            migrationBuilder.AddColumn<int>(
                name: "DepartementCodeDepartement",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupeCodeGroupe",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DepartementCodeDepartement",
                table: "Classes",
                column: "DepartementCodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GroupeCodeGroupe",
                table: "Classes",
                column: "GroupeCodeGroupe");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Departements_DepartementCodeDepartement",
                table: "Classes",
                column: "DepartementCodeDepartement",
                principalTable: "Departements",
                principalColumn: "CodeDepartement",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_groupes_GroupeCodeGroupe",
                table: "Classes",
                column: "GroupeCodeGroupe",
                principalTable: "groupes",
                principalColumn: "CodeGroupe",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
