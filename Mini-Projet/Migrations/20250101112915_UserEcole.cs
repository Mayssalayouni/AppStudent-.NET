using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Projet.Migrations
{
    /// <inheritdoc />
    public partial class UserEcole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEcoles",
                columns: table => new
                {
                    CodeUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrenomUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mdp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEcoles", x => x.CodeUser);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEcoles");
        }
    }
}
