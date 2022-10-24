using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoIntegrador.Migrations
{
    public partial class RELACAO_SALA_PROFESSOR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Salas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salas_ProfessorId",
                table: "Salas",
                column: "ProfessorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Professores_ProfessorId",
                table: "Salas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Professores_ProfessorId",
                table: "Salas");

            migrationBuilder.DropIndex(
                name: "IX_Salas_ProfessorId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Salas");
        }
    }
}
