using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UnComboTieneVariasComidas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Combos_combocodigo",
                table: "ComboComida");

            migrationBuilder.RenameColumn(
                name: "combocodigo",
                table: "ComboComida",
                newName: "Combocodigo");

            migrationBuilder.RenameIndex(
                name: "IX_ComboComida_combocodigo",
                table: "ComboComida",
                newName: "IX_ComboComida_Combocodigo");

            migrationBuilder.AlterColumn<int>(
                name: "Combocodigo",
                table: "ComboComida",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Combos_Combocodigo",
                table: "ComboComida",
                column: "Combocodigo",
                principalTable: "Combos",
                principalColumn: "codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Combos_Combocodigo",
                table: "ComboComida");

            migrationBuilder.RenameColumn(
                name: "Combocodigo",
                table: "ComboComida",
                newName: "combocodigo");

            migrationBuilder.RenameIndex(
                name: "IX_ComboComida_Combocodigo",
                table: "ComboComida",
                newName: "IX_ComboComida_combocodigo");

            migrationBuilder.AlterColumn<int>(
                name: "combocodigo",
                table: "ComboComida",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Combos_combocodigo",
                table: "ComboComida",
                column: "combocodigo",
                principalTable: "Combos",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
