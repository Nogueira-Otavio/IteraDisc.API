using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteraDisc.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class IcrementacaoNaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");
        }
    }
}
