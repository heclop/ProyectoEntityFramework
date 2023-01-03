using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPesoTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Tarea");
        }
    }
}
