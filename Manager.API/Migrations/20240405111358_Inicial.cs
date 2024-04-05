using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo_Construccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Especialidades = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ListaMiembros = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo_Construccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "maquinaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    capacidad = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    estadoMantenimiento = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    disponibilidad = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquinaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    materialStock = table.Column<int>(type: "int", nullable: false),
                    proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    deliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos_Construccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos_Construccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos_ConstruccionProyecto_Construccion",
                columns: table => new
                {
                    EquiposDeConstruccionId = table.Column<int>(type: "int", nullable: false),
                    ProyectosDeConstruccionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos_ConstruccionProyecto_Construccion", x => new { x.EquiposDeConstruccionId, x.ProyectosDeConstruccionId });
                    table.ForeignKey(
                        name: "FK_Equipos_ConstruccionProyecto_Construccion_Equipo_Construccion_EquiposDeConstruccionId",
                        column: x => x.EquiposDeConstruccionId,
                        principalTable: "Equipo_Construccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_ConstruccionProyecto_Construccion_Proyectos_Construccion_ProyectosDeConstruccionId",
                        column: x => x.ProyectosDeConstruccionId,
                        principalTable: "Proyectos_Construccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presupuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManoObra = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Materiales = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Maquinaria = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ProyectoDeConstruccionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuesto_Proyectos_Construccion_ProyectoDeConstruccionId",
                        column: x => x.ProyectoDeConstruccionId,
                        principalTable: "Proyectos_Construccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProyectoDeConstruccionId = table.Column<int>(type: "int", nullable: false),
                    Proyecto_ConstruccionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_Construccion_Proyecto_ConstruccionId",
                        column: x => x.Proyecto_ConstruccionId,
                        principalTable: "Proyectos_Construccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaquinariaTarea",
                columns: table => new
                {
                    MaquinariasId = table.Column<int>(type: "int", nullable: false),
                    TareasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinariaTarea", x => new { x.MaquinariasId, x.TareasId });
                    table.ForeignKey(
                        name: "FK_MaquinariaTarea_Tareas_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaquinariaTarea_maquinaria_MaquinariasId",
                        column: x => x.MaquinariasId,
                        principalTable: "maquinaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTarea",
                columns: table => new
                {
                    MaterialesId = table.Column<int>(type: "int", nullable: false),
                    tareasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTarea", x => new { x.MaterialesId, x.tareasId });
                    table.ForeignKey(
                        name: "FK_MaterialTarea_Materiales_MaterialesId",
                        column: x => x.MaterialesId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialTarea_Tareas_tareasId",
                        column: x => x.tareasId,
                        principalTable: "Tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_ConstruccionProyecto_Construccion_ProyectosDeConstruccionId",
                table: "Equipos_ConstruccionProyecto_Construccion",
                column: "ProyectosDeConstruccionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaquinariaTarea_TareasId",
                table: "MaquinariaTarea",
                column: "TareasId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTarea_tareasId",
                table: "MaterialTarea",
                column: "tareasId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuesto_ProyectoDeConstruccionId",
                table: "Presupuesto",
                column: "ProyectoDeConstruccionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Proyecto_ConstruccionId",
                table: "Tareas",
                column: "Proyecto_ConstruccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos_ConstruccionProyecto_Construccion");

            migrationBuilder.DropTable(
                name: "MaquinariaTarea");

            migrationBuilder.DropTable(
                name: "MaterialTarea");

            migrationBuilder.DropTable(
                name: "Presupuesto");

            migrationBuilder.DropTable(
                name: "Equipo_Construccion");

            migrationBuilder.DropTable(
                name: "maquinaria");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Proyectos_Construccion");
        }
    }
}
