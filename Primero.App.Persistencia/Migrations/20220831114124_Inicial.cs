using Microsoft.EntityFrameworkCore.Migrations;

namespace Primero.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatoMeteorologicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatoMeteorologicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador_Password = table.Column<int>(type: "int", nullable: true),
                    Administrador_Roll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<int>(type: "int", nullable: true),
                    Roll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    Longitud = table.Column<float>(type: "real", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMontaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnicoMantenimientoId = table.Column<int>(type: "int", nullable: true),
                    PersonalMonitoreoId = table.Column<int>(type: "int", nullable: true),
                    ReporteId = table.Column<int>(type: "int", nullable: true),
                    DatoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estaciones_DatoMeteorologicos_DatoId",
                        column: x => x.DatoId,
                        principalTable: "DatoMeteorologicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estaciones_Personas_PersonalMonitoreoId",
                        column: x => x.PersonalMonitoreoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estaciones_Personas_TecnicoMantenimientoId",
                        column: x => x.TecnicoMantenimientoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estaciones_Reportes_ReporteId",
                        column: x => x.ReporteId,
                        principalTable: "Reportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_DatoId",
                table: "Estaciones",
                column: "DatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_PersonalMonitoreoId",
                table: "Estaciones",
                column: "PersonalMonitoreoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_ReporteId",
                table: "Estaciones",
                column: "ReporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_TecnicoMantenimientoId",
                table: "Estaciones",
                column: "TecnicoMantenimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estaciones");

            migrationBuilder.DropTable(
                name: "DatoMeteorologicos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Reportes");
        }
    }
}
