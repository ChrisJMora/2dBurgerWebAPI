using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DefinicionValorHistoriales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComidasCombo_Producto_codigoCombo",
                table: "ComidasCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_ComidasCombo_Producto_codigoComida",
                table: "ComidasCombo");

            migrationBuilder.DropTable(
                name: "AtributoProducto<decimal>");

            migrationBuilder.DropTable(
                name: "AtributoProducto<string>");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComidasCombo",
                table: "ComidasCombo");

            migrationBuilder.RenameTable(
                name: "ComidasCombo",
                newName: "ComboComida");

            migrationBuilder.RenameIndex(
                name: "IX_ComidasCombo_codigoComida",
                table: "ComboComida",
                newName: "IX_ComboComida_codigoComida");

            migrationBuilder.RenameIndex(
                name: "IX_ComidasCombo_codigoCombo",
                table: "ComboComida",
                newName: "IX_ComboComida_codigoCombo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboComida",
                table: "ComboComida",
                column: "codigo");

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoNombreActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescripcionActual = table.Column<int>(type: "int", nullable: false),
                    codigoPrecioActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Comidas",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoNombreActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescripcionActual = table.Column<int>(type: "int", nullable: false),
                    codigoPrecioActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comidas", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "HistorialDescripciones",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<string>(type: "varchar(100)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialDescripciones", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "HistorialDescuentos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialDescuentos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "HistorialNombres",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<string>(type: "varchar(50)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialNombres", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "HistorialPrecios",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialPrecios", x => x.codigo);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Combos_codigoCombo",
                table: "ComboComida",
                column: "codigoCombo",
                principalTable: "Combos",
                principalColumn: "codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Comidas_codigoComida",
                table: "ComboComida",
                column: "codigoComida",
                principalTable: "Comidas",
                principalColumn: "codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Combos_codigoCombo",
                table: "ComboComida");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Comidas_codigoComida",
                table: "ComboComida");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Comidas");

            migrationBuilder.DropTable(
                name: "HistorialDescripciones");

            migrationBuilder.DropTable(
                name: "HistorialDescuentos");

            migrationBuilder.DropTable(
                name: "HistorialNombres");

            migrationBuilder.DropTable(
                name: "HistorialPrecios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboComida",
                table: "ComboComida");

            migrationBuilder.RenameTable(
                name: "ComboComida",
                newName: "ComidasCombo");

            migrationBuilder.RenameIndex(
                name: "IX_ComboComida_codigoComida",
                table: "ComidasCombo",
                newName: "IX_ComidasCombo_codigoComida");

            migrationBuilder.RenameIndex(
                name: "IX_ComboComida_codigoCombo",
                table: "ComidasCombo",
                newName: "IX_ComidasCombo_codigoCombo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComidasCombo",
                table: "ComidasCombo",
                column: "codigo");

            migrationBuilder.CreateTable(
                name: "AtributoProducto<decimal>",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributoProducto<decimal>", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "AtributoProducto<string>",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributoProducto<string>", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoDescripcionActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false),
                    codigoNombreActual = table.Column<int>(type: "int", nullable: false),
                    codigoPrecioActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.codigo);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComidasCombo_Producto_codigoCombo",
                table: "ComidasCombo",
                column: "codigoCombo",
                principalTable: "Producto",
                principalColumn: "codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComidasCombo_Producto_codigoComida",
                table: "ComidasCombo",
                column: "codigoComida",
                principalTable: "Producto",
                principalColumn: "codigo");
        }
    }
}
