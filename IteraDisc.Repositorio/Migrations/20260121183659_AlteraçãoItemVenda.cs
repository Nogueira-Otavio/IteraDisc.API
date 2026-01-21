using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteraDisc.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãoItemVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "ItemVenda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "VendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "ItemVenda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
