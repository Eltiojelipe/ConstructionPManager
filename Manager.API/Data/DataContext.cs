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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Proyecto_Construccion>()
            .HasOne(proyecto => proyecto.Presupuesto)
            .WithOne(presupuesto => presupuesto.Proyecto_Construccion)
            .HasForeignKey<Presupuesto>(presupuesto => presupuesto.ProyectoDeConstruccionId);

            modelBuilder.Entity<Maquinaria>()
        .HasKey(m => m.Id);

            modelBuilder.Entity<Presupuesto>()
        .HasKey(p => p.Id);


        }

    }

}