using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaAsociacionProductoHistoriales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialComidas_Producto_codigoCombo",
                table: "HistorialComidas");

            migrationBuilder.DropIndex(
                name: "IX_HistorialComidas_codigoCombo",
                table: "HistorialComidas");

            migrationBuilder.RenameColumn(
                name: "codigoCombo",
                table: "HistorialComidas",
                newName: "codigoProducto");

            migrationBuilder.AddColumn<int>(
                name: "comidasActualescodigo",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "descripcionActualcodigo",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "descuentoActualcodigo",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "precioActualcodigo",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "codigoProducto",
                table: "HistorialPrecios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "codigoProducto",
                table: "HistorialDescuentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "codigoProducto",
                table: "HistorialDescripciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_comidasActualescodigo",
                table: "Producto",
                column: "comidasActualescodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_descripcionActualcodigo",
                table: "Producto",
                column: "descripcionActualcodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_descuentoActualcodigo",
                table: "Producto",
                column: "descuentoActualcodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_precioActualcodigo",
                table: "Producto",
                column: "precioActualcodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_HistorialComidas_comidasActualescodigo",
                table: "Producto",
                column: "comidasActualescodigo",
                principalTable: "HistorialComidas",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_HistorialDescripciones_descripcionActualcodigo",
                table: "Producto",
                column: "descripcionActualcodigo",
                principalTable: "HistorialDescripciones",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_HistorialDescuentos_descuentoActualcodigo",
                table: "Producto",
                column: "descuentoActualcodigo",
                principalTable: "HistorialDescuentos",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_HistorialPrecios_precioActualcodigo",
                table: "Producto",
                column: "precioActualcodigo",
                principalTable: "HistorialPrecios",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_HistorialComidas_comidasActualescodigo",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_HistorialDescripciones_descripcionActualcodigo",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_HistorialDescuentos_descuentoActualcodigo",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_HistorialPrecios_precioActualcodigo",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_comidasActualescodigo",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_descripcionActualcodigo",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_descuentoActualcodigo",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_precioActualcodigo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "comidasActualescodigo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "descripcionActualcodigo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "descuentoActualcodigo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "precioActualcodigo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "codigoProducto",
                table: "HistorialPrecios");

            migrationBuilder.DropColumn(
                name: "codigoProducto",
                table: "HistorialDescuentos");

            migrationBuilder.DropColumn(
                name: "codigoProducto",
                table: "HistorialDescripciones");

            migrationBuilder.RenameColumn(
                name: "codigoProducto",
                table: "HistorialComidas",
                newName: "codigoCombo");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialComidas_codigoCombo",
                table: "HistorialComidas",
                column: "codigoCombo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialComidas_Producto_codigoCombo",
                table: "HistorialComidas",
                column: "codigoCombo",
                principalTable: "Producto",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
