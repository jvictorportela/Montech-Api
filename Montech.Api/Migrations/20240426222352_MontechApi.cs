using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Montech.Api.Migrations;

/// <inheritdoc />
public partial class MontechApi : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Categoria",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categoria", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Empresa",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Empresa", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Usuario",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Usuario", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Produtos",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Nome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Codigo = table.Column<int>(type: "int", nullable: false),
                CategoriaId = table.Column<int>(type: "int", nullable: false),
                Descricao = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                ValorMercado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Produtos", x => x.Id);
                table.ForeignKey(
                    name: "FK_Produtos_Categoria_CategoriaId",
                    column: x => x.CategoriaId,
                    principalTable: "Categoria",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Produtos_CategoriaId",
            table: "Produtos",
            column: "CategoriaId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Empresa");

        migrationBuilder.DropTable(
            name: "Produtos");

        migrationBuilder.DropTable(
            name: "Usuario");

        migrationBuilder.DropTable(
            name: "Categoria");
    }
}
