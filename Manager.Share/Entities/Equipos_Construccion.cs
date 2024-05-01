using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class Equipos_Construccion
    {
        public int Id { get; set; }


        [Display(Name = "Nombre del equipo de construcción")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Nombre { get; set; }


        [Display(Name = "Especialidades del equipo")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Especialidades { get; set; }


        [Display(Name = "Lista de miembros del equipo")]
        [MaxLength(30, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string ListaMiembros { get; set; }


        [JsonIgnore]

        public ICollection<Equipos_Proy_Construccion> Equipos_Proy { get; set; }
    }
}
