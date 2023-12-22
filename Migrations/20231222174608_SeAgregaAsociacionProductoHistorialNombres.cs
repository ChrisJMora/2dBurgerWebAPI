using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaAsociacionProductoHistorialNombres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Comidas_comidacodigo",
                table: "ComboComida");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialComidas_Combos_codigoCombo",
                table: "HistorialComidas");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comidas",
                table: "Comidas");

            migrationBuilder.RenameTable(
                name: "Comidas",
                newName: "Producto");

            migrationBuilder.RenameColumn(
                name: "codigoCombo",
                table: "ComboComida",
                newName: "codigoHistorialComida");

            migrationBuilder.AddColumn<int>(
                name: "codigoProducto",
                table: "HistorialNombres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Producto",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "codigo");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialNombres_codigoProducto",
                table: "HistorialNombres",
                column: "codigoProducto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Producto_comidacodigo",
                table: "ComboComida",
                column: "comidacodigo",
                principalTable: "Producto",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialComidas_Producto_codigoCombo",
                table: "HistorialComidas",
                column: "codigoCombo",
                principalTable: "Producto",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialNombres_Producto_codigoProducto",
                table: "HistorialNombres",
                column: "codigoProducto",
                principalTable: "Producto",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Producto_comidacodigo",
                table: "ComboComida");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialComidas_Producto_codigoCombo",
                table: "HistorialComidas");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialNombres_Producto_codigoProducto",
                table: "HistorialNombres");

            migrationBuilder.DropIndex(
                name: "IX_HistorialNombres_codigoProducto",
                table: "HistorialNombres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "codigoProducto",
                table: "HistorialNombres");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Producto");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Comidas");

            migrationBuilder.RenameColumn(
                name: "codigoHistorialComida",
                table: "ComboComida",
                newName: "codigoCombo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comidas",
                table: "Comidas",
                column: "codigo");

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    codigoDescripcionActual = table.Column<int>(type: "int", nullable: false),
                    codigoDescuentoActual = table.Column<int>(type: "int", nullable: false),
                    codigoNombreActual = table.Column<int>(type: "int", nullable: false),
                    codigoPrecioActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.codigo);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Comidas_comidacodigo",
                table: "ComboComida",
                column: "comidacodigo",
                principalTable: "Comidas",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialComidas_Combos_codigoCombo",
                table: "HistorialComidas",
                column: "codigoCombo",
                principalTable: "Combos",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
