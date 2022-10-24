using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoIntegrador.Migrations
{
    public partial class Relaca_SALAALUNOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Alunos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_SalaId",
                table: "Alunos",
                column: "SalaId");

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

            migrationBuilder.DropIndex(
                name: "IX_Alunos_SalaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Alunos");
        }
    }
}
