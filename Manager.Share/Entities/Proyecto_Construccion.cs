using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class Proyecto_Construccion
    {
        public int Id { get; set; }


        [Display(Name = "Nombre del proyecto de construcción")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Nombre { get; set; }


        [Display(Name = "Ubicación del proyecto")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Ubicacion { get; set; }

        
        [Display(Name = "Descripción del proyecto")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Descripcion { get; set; }

        
        [Display(Name = "Fecha de Inicio del proyecto")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }


        [Display(Name = "Fecha estimada de finalización del proyecto")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
        
        [JsonIgnore]
        public ICollection<Equipos_Construccion> EquiposDeConstruccion { get; set; }

        [JsonIgnore]
        public ICollection<Tarea> Tareas { get; set; }

        [JsonIgnore]
        public Presupuesto Presupuesto { get; set; }
    }

}

