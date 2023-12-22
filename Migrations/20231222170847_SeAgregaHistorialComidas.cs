using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaHistorialComidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_Combos_Combocodigo",
                table: "ComboComida");

            migrationBuilder.RenameColumn(
                name: "Combocodigo",
                table: "ComboComida",
                newName: "HistorialComidascodigo");

            migrationBuilder.RenameIndex(
                name: "IX_ComboComida_Combocodigo",
                table: "ComboComida",
                newName: "IX_ComboComida_HistorialComidascodigo");

            migrationBuilder.CreateTable(
                name: "HistorialComidas",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoCombo = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialComidas", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_HistorialComidas_Combos_codigoCombo",
                        column: x => x.codigoCombo,
                        principalTable: "Combos",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialComidas_codigoCombo",
                table: "HistorialComidas",
                column: "codigoCombo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_HistorialComidas_HistorialComidascodigo",
                table: "ComboComida",
                column: "HistorialComidascodigo",
                principalTable: "HistorialComidas",
                principalColumn: "codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboComida_HistorialComidas_HistorialComidascodigo",
                table: "ComboComida");

            migrationBuilder.DropTable(
                name: "HistorialComidas");

            migrationBuilder.RenameColumn(
                name: "HistorialComidascodigo",
                table: "ComboComida",
                newName: "Combocodigo");

            migrationBuilder.RenameIndex(
                name: "IX_ComboComida_HistorialComidascodigo",
                table: "ComboComida",
                newName: "IX_ComboComida_Combocodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboComida_Combos_Combocodigo",
                table: "ComboComida",
                column: "Combocodigo",
                principalTable: "Combos",
                principalColumn: "codigo");
        }
    }
}
