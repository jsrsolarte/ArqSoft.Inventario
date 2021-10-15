using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventario.Api.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inventario");

            migrationBuilder.CreateTable(
                name: "Almacen",
                schema: "inventario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "inventario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    AlmacenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Almacen_AlmacenId",
                        column: x => x.AlmacenId,
                        principalSchema: "inventario",
                        principalTable: "Almacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_AlmacenId",
                schema: "inventario",
                table: "Producto",
                column: "AlmacenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto",
                schema: "inventario");

            migrationBuilder.DropTable(
                name: "Almacen",
                schema: "inventario");
        }
    }
}
