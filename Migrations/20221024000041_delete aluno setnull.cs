using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoIntegrador.Migrations
{
    public partial class deletealunosetnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Salas_SalaId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Salas_SalaId",
                table: "Alunos",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Salas_SalaId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Salas_SalaId",
                table: "Alunos",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }
    }
}
