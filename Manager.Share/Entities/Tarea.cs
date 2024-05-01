using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class Tarea
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la tarea")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string taskName { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(250, ErrorMessage = "No se permiten más de 250 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime DateStarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime DateFinished { get; set; }

        [JsonIgnore]
        public int ProyectoDeConstruccionId { get; set; }
        public Proyecto_Construccion Proyecto_Construccion { get; set; }

        [JsonIgnore]
        public ICollection<MaterialTarea> MaterialTarea { get; set; }

        [JsonIgnore]
        public ICollection<MaquinariaTarea> MaquinariasTarea { get; set; }
    }
}
