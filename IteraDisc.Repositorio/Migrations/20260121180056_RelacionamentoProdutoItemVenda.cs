using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteraDisc.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoProdutoItemVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Produto_ProdutoId",
                table: "ItemVenda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Produto_ProdutoId",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoId",
                table: "ItemVenda");
        }
    }
}
