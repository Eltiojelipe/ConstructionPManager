using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Share.Entities
{
    public class Presupuesto
    {
        public int idPresupuesto { get; set; }

        [Display(Name = "Mano de obra")]
        [MaxLength(13, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string ManoObra { get; set; }

        [Display(Name = "Nombre de los materiales")]
        [MaxLength(13, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Materiales { get; set; }

        [Display(Name = "Maquinaria")]
        [MaxLength(13, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Maquinaria { get; set; }

    }
}
