using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteraDisc.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoPropriedadeDescartadoItemVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItensId",
                table: "Venda");

            migrationBuilder.AddColumn<bool>(
                name: "Descartado",
                table: "ItemVenda",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descartado",
                table: "ItemVenda");

            migrationBuilder.AddColumn<string>(
                name: "ItensId",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
