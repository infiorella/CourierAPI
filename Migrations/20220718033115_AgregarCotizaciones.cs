using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnionStarAPI.Migrations
{
    public partial class AgregarCotizaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    IdCotizacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importe = table.Column<double>(type: "float", nullable: false),
                    ModoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdInteresado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdObjeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlazoEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CondicionesEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPersonal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdServicio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.IdCotizacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizaciones");
        }
    }
}
