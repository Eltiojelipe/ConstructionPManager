using Manager.Share.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Manager.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Proyecto_Construccion> Proyectos_Construccion { get; set; }
        public DbSet<Equipos_Construccion> Equipo_Construccion { get; set; }
        public DbSet<Maquinaria> maquinaria { get; set; }
        public DbSet<Presupuesto> Presupuesto { get; set; }
        public DbSet<Equipos_Proy_Construccion> proy_Construccions { get; set; }
        public DbSet<MaquinariaTarea> maquinariaTareas { get; set; }
        public DbSet<MaterialTarea> MaterialTareas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}