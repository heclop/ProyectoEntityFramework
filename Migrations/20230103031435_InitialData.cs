using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("b872a04c-e096-46c1-bb26-6679d043a802"), null, "Actividades personales", 50 },
                    { new Guid("b872a04c-e096-46c1-bb26-6679d043a8fb"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Peso", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("b872a04c-e096-46c1-bb26-6679d043a849"), new Guid("b872a04c-e096-46c1-bb26-6679d043a802"), null, new DateTime(2023, 1, 2, 22, 14, 35, 96, DateTimeKind.Local).AddTicks(4863), 5, 0, "Terminar de ver pelicula en Netflix" },
                    { new Guid("b872a04c-e096-46c1-bb26-6679d043a8fb"), new Guid("b872a04c-e096-46c1-bb26-6679d043a8fb"), null, new DateTime(2023, 1, 2, 22, 14, 35, 96, DateTimeKind.Local).AddTicks(4848), 10, 1, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b872a04c-e096-46c1-bb26-6679d043a849"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b872a04c-e096-46c1-bb26-6679d043a8fb"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("b872a04c-e096-46c1-bb26-6679d043a802"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("b872a04c-e096-46c1-bb26-6679d043a8fb"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
