using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyProductoComidasCombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ComidasCombo_codigoCombo",
                table: "ComidasCombo",
                column: "codigoCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ComidasCombo_codigoComida",
                table: "ComidasCombo",
                column: "codigoComida");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComidasCombo_Producto_codigoCombo",
                table: "ComidasCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_ComidasCombo_Producto_codigoComida",
                table: "ComidasCombo");

            migrationBuilder.DropIndex(
                name: "IX_ComidasCombo_codigoCombo",
                table: "ComidasCombo");

            migrationBuilder.DropIndex(
                name: "IX_ComidasCombo_codigoComida",
                table: "ComidasCombo");
        }
    }
}
