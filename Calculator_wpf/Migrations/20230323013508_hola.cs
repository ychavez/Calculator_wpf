using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculator_wpf.Migrations
{
    /// <inheritdoc />
    public partial class hola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "sales",
                table: "order_items");

            migrationBuilder.EnsureSchema(
                name: "EsteEsquema");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "sales",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstaEsLaTabla",
                schema: "EsteEsquema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstaEsLaTabla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prueba",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nommbre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__prueba__3213E83F35EF9782", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstaEsLaTabla",
                schema: "EsteEsquema");

            migrationBuilder.DropTable(
                name: "prueba");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "sales",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "sales",
                table: "order_items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
