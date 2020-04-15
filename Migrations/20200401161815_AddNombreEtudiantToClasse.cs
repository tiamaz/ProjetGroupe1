using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetGroupe1.Migrations
{
    public partial class AddNombreEtudiantToClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NombreEtudiant",
                table: "classe",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreEtudiant",
                table: "classe");
        }
    }
}
