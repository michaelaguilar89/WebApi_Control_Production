using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiControlProduction.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tanque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    horaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nivelFinal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responsable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productions");
        }
    }
}
