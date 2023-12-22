using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2dBurgerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CampoActivoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Comidas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Combos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activo",
                table: "Comidas");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "Combos");
        }
    }
}
