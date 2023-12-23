using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialComidas",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialComidas", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "HistorialDescripciones",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<string>(type: "varchar(100)", nullable: false)
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
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
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
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<string>(type: "varchar(50)", nullable: false)
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
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialPrecios", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoNombreActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescripcionActual = table.Column<int>(type: "int", nullable: false),
                    codigoPrecioActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    codigoComidasActuales = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_Producto_HistorialComidas_codigoComidasActuales",
                        column: x => x.codigoComidasActuales,
                        principalTable: "HistorialComidas",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_HistorialDescripciones_codigoDescripcionActual",
                        column: x => x.codigoDescripcionActual,
                        principalTable: "HistorialDescripciones",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_HistorialDescuentos_codigoDescuentoActual",
                        column: x => x.codigoDescuentoActual,
                        principalTable: "HistorialDescuentos",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_HistorialNombres_codigoNombreActual",
                        column: x => x.codigoNombreActual,
                        principalTable: "HistorialNombres",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_HistorialPrecios_codigoPrecioActual",
                        column: x => x.codigoPrecioActual,
                        principalTable: "HistorialPrecios",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboComida",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    codigoHistorialComida = table.Column<int>(type: "int", nullable: false),
                    codigoComida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboComida", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_ComboComida_HistorialComidas_codigoHistorialComida",
                        column: x => x.codigoHistorialComida,
                        principalTable: "HistorialComidas",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_ComboComida_Producto_codigoComida",
                        column: x => x.codigoComida,
                        principalTable: "Producto",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_codigoComida",
                table: "ComboComida",
                column: "codigoComida");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_codigoHistorialComida",
                table: "ComboComida",
                column: "codigoHistorialComida");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codigoComidasActuales",
                table: "Producto",
                column: "codigoComidasActuales",
                unique: true,
                filter: "[codigoComidasActuales] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codigoDescripcionActual",
                table: "Producto",
                column: "codigoDescripcionActual",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codigoDescuentoActual",
                table: "Producto",
                column: "codigoDescuentoActual",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codigoNombreActual",
                table: "Producto",
                column: "codigoNombreActual",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codigoPrecioActual",
                table: "Producto",
                column: "codigoPrecioActual",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboComida");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "HistorialComidas");

            migrationBuilder.DropTable(
                name: "HistorialDescripciones");

            migrationBuilder.DropTable(
                name: "HistorialDescuentos");

            migrationBuilder.DropTable(
                name: "HistorialNombres");

            migrationBuilder.DropTable(
                name: "HistorialPrecios");
        }
    }
}
