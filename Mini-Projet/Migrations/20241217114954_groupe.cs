using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class groupe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Groupe_GroupeCodeGroupe",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groupe",
                table: "Groupe");

            migrationBuilder.RenameTable(
                name: "Groupe",
                newName: "groupes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_groupes",
                table: "groupes",
                column: "CodeGroupe");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_groupes_GroupeCodeGroupe",
                table: "Classes",
                column: "GroupeCodeGroupe",
                principalTable: "groupes",
                principalColumn: "CodeGroupe",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_groupes_GroupeCodeGroupe",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_groupes",
                table: "groupes");

            migrationBuilder.RenameTable(
                name: "groupes",
                newName: "Groupe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groupe",
                table: "Groupe",
                column: "CodeGroupe");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Groupe_GroupeCodeGroupe",
                table: "Classes",
                column: "GroupeCodeGroupe",
                principalTable: "Groupe",
                principalColumn: "CodeGroupe",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
