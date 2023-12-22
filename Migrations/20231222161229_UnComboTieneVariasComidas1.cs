using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UnComboTieneVariasComidas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Combos_codigoCombo",
                table: "ComboComida");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Comidas_codigoComida",
                table: "ComboComida");

            migrationBuilder.DropIndex(
                name: "IX_ComboComida_codigoCombo",
                table: "ComboComida");

            migrationBuilder.DropIndex(
                name: "IX_ComboComida_codigoComida",
                table: "ComboComida");

            migrationBuilder.AddColumn<int>(
                name: "combocodigo",
                table: "ComboComida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "comidacodigo",
                table: "ComboComida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_combocodigo",
                table: "ComboComida",
                column: "combocodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_comidacodigo",
                table: "ComboComida",
                column: "comidacodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Combos_combocodigo",
                table: "ComboComida",
                column: "combocodigo",
                principalTable: "Combos",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Comidas_comidacodigo",
                table: "ComboComida",
                column: "comidacodigo",
                principalTable: "Comidas",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Combos_combocodigo",
                table: "ComboComida");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Comidas_comidacodigo",
                table: "ComboComida");

            migrationBuilder.DropIndex(
                name: "IX_ComboComida_combocodigo",
                table: "ComboComida");

            migrationBuilder.DropIndex(
                name: "IX_ComboComida_comidacodigo",
                table: "ComboComida");

            migrationBuilder.DropColumn(
                name: "combocodigo",
                table: "ComboComida");

            migrationBuilder.DropColumn(
                name: "comidacodigo",
                table: "ComboComida");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_codigoCombo",
                table: "ComboComida",
                column: "codigoCombo");

            migrationBuilder.CreateIndex(
                name: "IX_ComboComida_codigoComida",
                table: "ComboComida",
                column: "codigoComida");

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
    }
}
