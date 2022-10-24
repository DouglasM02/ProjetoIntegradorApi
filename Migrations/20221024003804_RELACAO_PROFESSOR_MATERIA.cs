using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoIntegrador.Migrations
{
    public partial class RELACAO_PROFESSOR_MATERIA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Materias",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfessorId",
                table: "Materias",
                column: "ProfessorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Professores_ProfessorId",
                table: "Materias",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Professores_ProfessorId",
                table: "Materias");

            migrationBuilder.DropIndex(
                name: "IX_Materias_ProfessorId",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Materias");
        }
    }
}
