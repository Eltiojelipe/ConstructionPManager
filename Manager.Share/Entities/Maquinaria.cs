using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class Maquinaria
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la maquinaria")]
        [MaxLength(13, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string nombre { get; set; }

        [Display(Name = "capacidad de la maquinaria")]
        [MaxLength(13, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string capacidad { get; set; }

        [Display(Name = "Estado del mantenimiento")]
        [MaxLength(13, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string estadoMantenimiento {  get; set; }

        [Display(Name = "Disponibilidad")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public bool disponibilidad {  get; set; }

        [JsonIgnore]
        public ICollection<Tarea> Tareas { get; set; }
        //public int Id { get; set; }
    }
}
