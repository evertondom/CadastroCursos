using Microsoft.EntityFrameworkCore.Migrations;

namespace BackCursos.Migrations
{
    public partial class atualizacaoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Curso_CategoriaId",
                table: "Curso",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Categoria_CategoriaId",
                table: "Curso",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Categoria_CategoriaId",
                table: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Curso_CategoriaId",
                table: "Curso");
        }
    }
}
