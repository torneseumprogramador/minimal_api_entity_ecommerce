using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimalApi_entity.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_Clientes_ClienteId",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "pedidos",
                newName: "data");

            migrationBuilder.RenameColumn(
                name: "ValorPedido",
                table: "pedidos",
                newName: "valor_pedido");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "pedidos",
                newName: "cliente_id");

            migrationBuilder.RenameIndex(
                name: "IX_pedidos_ClienteId",
                table: "pedidos",
                newName: "IX_pedidos_cliente_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pedidosProdutos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pedido_id = table.Column<int>(type: "int", nullable: false),
                    produto_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidosProdutos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedidosProdutos_pedidos_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidosProdutos_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_pedidosProdutos_pedido_id",
                table: "pedidosProdutos",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidosProdutos_produto_id",
                table: "pedidosProdutos",
                column: "produto_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_clientes_cliente_id",
                table: "pedidos",
                column: "cliente_id",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_clientes_cliente_id",
                table: "pedidos");

            migrationBuilder.DropTable(
                name: "pedidosProdutos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "pedidos",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "valor_pedido",
                table: "pedidos",
                newName: "ValorPedido");

            migrationBuilder.RenameColumn(
                name: "cliente_id",
                table: "pedidos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_pedidos_cliente_id",
                table: "pedidos",
                newName: "IX_pedidos_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_Clientes_ClienteId",
                table: "pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
