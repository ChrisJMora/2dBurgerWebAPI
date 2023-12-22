using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UnComboTieneVariasComidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoNombreActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescripcionActual = table.Column<int>(type: "int", nullable: false),
                    codigoPrecioActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
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
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ComboComida",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoCombo = table.Column<int>(type: "int", nullable: false),
                    codigoComida = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboComida", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_ComboComida_Combos_codigoCombo",
                        column: x => x.codigoCombo,
                        principalTable: "Combos",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_ComboComida_Comidas_codigoComida",
                        column: x => x.codigoComida,
                        principalTable: "Comidas",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_codigoCombo",
                table: "ComboComida",
                column: "codigoCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_codigoComida",
                table: "ComboComida",
                column: "codigoComida");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboComida");

            migrationBuilder.DropTable(
                name: "HistorialDescripciones");

            migrationBuilder.DropTable(
                name: "HistorialDescuentos");

            migrationBuilder.DropTable(
                name: "HistorialNombres");

            migrationBuilder.DropTable(
                name: "HistorialPrecios");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Comidas");
        }
    }
}
