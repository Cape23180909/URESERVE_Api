using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URESERVE_Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cubiculos",
                columns: table => new
                {
                    CubiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cubiculos", x => x.CubiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Facultad = table.Column<string>(type: "TEXT", nullable: false),
                    Carrera = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    LaboratorioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.LaboratorioId);
                });

            migrationBuilder.CreateTable(
                name: "Proyectores",
                columns: table => new
                {
                    ProyectorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Conectividad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectores", x => x.ProyectorId);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    ReporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoReporte = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GeneradoPor = table.Column<string>(type: "TEXT", nullable: false),
                    TotalReservas = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservasActivas = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservasCanceladas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.ReporteId);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    ReservacionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    RestauranteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestauranteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposCargo",
                columns: table => new
                {
                    TipoCargoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCargo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCargo", x => x.TipoCargoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CorreoInstitucional = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Clave = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId");
                });

            migrationBuilder.CreateTable(
                name: "DetallesReservaProyectores",
                columns: table => new
                {
                    DetalleReservaProyectorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProyector = table.Column<int>(type: "INTEGER", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    ProyectorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesReservaProyectores", x => x.DetalleReservaProyectorId);
                    table.ForeignKey(
                        name: "FK_DetallesReservaProyectores_Proyectores_ProyectorId",
                        column: x => x.ProyectorId,
                        principalTable: "Proyectores",
                        principalColumn: "ProyectorId");
                });

            migrationBuilder.CreateTable(
                name: "DetallesReservaCubiculos",
                columns: table => new
                {
                    DetalleReservaCubiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCubiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    CubiculoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesReservaCubiculos", x => x.DetalleReservaCubiculoId);
                    table.ForeignKey(
                        name: "FK_DetallesReservaCubiculos_Cubiculos_CubiculoId",
                        column: x => x.CubiculoId,
                        principalTable: "Cubiculos",
                        principalColumn: "CubiculoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservaCubiculos_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservaCubiculos_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesReservaLaboratorios",
                columns: table => new
                {
                    DetalleReservaLaboratorioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    IdLaboratorio = table.Column<int>(type: "INTEGER", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    LaboratorioId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesReservaLaboratorios", x => x.DetalleReservaLaboratorioId);
                    table.ForeignKey(
                        name: "FK_DetallesReservaLaboratorios_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservaLaboratorios_Laboratorios_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "LaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservaLaboratorios_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesReservaRestaurantes",
                columns: table => new
                {
                    DetalleReservaRestauranteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    IdRestaurante = table.Column<int>(type: "INTEGER", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    RestauranteId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesReservaRestaurantes", x => x.DetalleReservaRestauranteId);
                    table.ForeignKey(
                        name: "FK_DetallesReservaRestaurantes_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservaRestaurantes_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservaRestaurantes_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestauranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaCubiculos_CubiculoId",
                table: "DetallesReservaCubiculos",
                column: "CubiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaCubiculos_EstudianteId",
                table: "DetallesReservaCubiculos",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaCubiculos_ReservacionId",
                table: "DetallesReservaCubiculos",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaLaboratorios_EstudianteId",
                table: "DetallesReservaLaboratorios",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaLaboratorios_LaboratorioId",
                table: "DetallesReservaLaboratorios",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaLaboratorios_ReservacionId",
                table: "DetallesReservaLaboratorios",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaProyectores_ProyectorId",
                table: "DetallesReservaProyectores",
                column: "ProyectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaRestaurantes_EstudianteId",
                table: "DetallesReservaRestaurantes",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaRestaurantes_ReservacionId",
                table: "DetallesReservaRestaurantes",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservaRestaurantes_RestauranteId",
                table: "DetallesReservaRestaurantes",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstudianteId",
                table: "Usuarios",
                column: "EstudianteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesReservaCubiculos");

            migrationBuilder.DropTable(
                name: "DetallesReservaLaboratorios");

            migrationBuilder.DropTable(
                name: "DetallesReservaProyectores");

            migrationBuilder.DropTable(
                name: "DetallesReservaRestaurantes");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "TiposCargo");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cubiculos");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Proyectores");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
