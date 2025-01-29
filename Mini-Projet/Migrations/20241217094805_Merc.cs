using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class Merc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiants_Classes_ClasseCodeClasse",
                table: "Etudiants");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseCodeClasse",
                table: "Etudiants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiants_Classes_ClasseCodeClasse",
                table: "Etudiants",
                column: "ClasseCodeClasse",
                principalTable: "Classes",
                principalColumn: "CodeClasse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiants_Classes_ClasseCodeClasse",
                table: "Etudiants");

            migrationBuilder.AlterColumn<int>(
                name: "ClasseCodeClasse",
                table: "Etudiants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiants_Classes_ClasseCodeClasse",
                table: "Etudiants",
                column: "ClasseCodeClasse",
                principalTable: "Classes",
                principalColumn: "CodeClasse",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
