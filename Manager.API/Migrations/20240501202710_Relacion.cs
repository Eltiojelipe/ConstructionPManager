using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.API.Migrations
{
    /// <inheritdoc />
    public partial class Relacion : Migration
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
                name: "Presupuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManoObra = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Materiales = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Maquinaria = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuesto", x => x.Id);
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
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PresupuestoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos_Construccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Construccion_Presupuesto_PresupuestoId",
                        column: x => x.PresupuestoId,
                        principalTable: "Presupuesto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "proy_Construccions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equiposId = table.Column<int>(type: "int", nullable: true),
                    proyectoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proy_Construccions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proy_Construccions_Equipo_Construccion_equiposId",
                        column: x => x.equiposId,
                        principalTable: "Equipo_Construccion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_proy_Construccions_Proyectos_Construccion_proyectoId",
                        column: x => x.proyectoId,
                        principalTable: "Proyectos_Construccion",
                        principalColumn: "Id");
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
                name: "maquinariaTareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TareaId = table.Column<int>(type: "int", nullable: true),
                    MaquinariaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquinariaTareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maquinariaTareas_Tareas_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tareas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_maquinariaTareas_maquinaria_MaquinariaId",
                        column: x => x.MaquinariaId,
                        principalTable: "maquinaria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialTareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    TareaId = table.Column<int>(type: "int", nullable: true),
                    MaquinariaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialTareas_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialTareas_Tareas_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tareas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialTareas_maquinaria_MaquinariaId",
                        column: x => x.MaquinariaId,
                        principalTable: "maquinaria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_maquinariaTareas_MaquinariaId",
                table: "maquinariaTareas",
                column: "MaquinariaId");

            migrationBuilder.CreateIndex(
                name: "IX_maquinariaTareas_TareaId",
                table: "maquinariaTareas",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTareas_MaquinariaId",
                table: "MaterialTareas",
                column: "MaquinariaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTareas_MaterialId",
                table: "MaterialTareas",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTareas_TareaId",
                table: "MaterialTareas",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_proy_Construccions_equiposId",
                table: "proy_Construccions",
                column: "equiposId");

            migrationBuilder.CreateIndex(
                name: "IX_proy_Construccions_proyectoId",
                table: "proy_Construccions",
                column: "proyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Construccion_PresupuestoId",
                table: "Proyectos_Construccion",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Proyecto_ConstruccionId",
                table: "Tareas",
                column: "Proyecto_ConstruccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "maquinariaTareas");

            migrationBuilder.DropTable(
                name: "MaterialTareas");

            migrationBuilder.DropTable(
                name: "proy_Construccions");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "maquinaria");

            migrationBuilder.DropTable(
                name: "Equipo_Construccion");

            migrationBuilder.DropTable(
                name: "Proyectos_Construccion");

            migrationBuilder.DropTable(
                name: "Presupuesto");
        }
    }
}
